using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Azure.Storage.Blobs;

namespace Formacion.Azure.AppService.WebJobs.WebUploadFiles.Controllers
{
    public class WebJobsController : Controller
    {

        [BindProperty]
        public IFormFile UploadFileContent { get; set; }

        private readonly IConfiguration config;

        public WebJobsController(IConfiguration config)
        {
            this.config = config;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ficheros()
        {
            var files = Directory.GetFiles(Directory.GetCurrentDirectory() + @"\wwwroot\process\");
            List<string> urls = new List<string>();

            foreach (var file in files)
            {
                var fileInfo = new FileInfo(file);
                urls.Add($"/process/{fileInfo.Name}");
            }

            return View(urls);
        }

        public IActionResult UploadFile()
        {
            try
            {
                if (UploadFileContent == null || UploadFileContent.Length == 0)
                    return Content("Fichero no seleccionado.");

                var ruta = Path.Combine(
                    Directory.GetCurrentDirectory(),
                    "wwwroot",
                    "upload",
                    UploadFileContent.FileName);

                using (var stream = new FileStream(ruta, FileMode.Create))
                {
                    UploadFileContent.CopyTo(stream);
                    stream.Close();
                }

            }
            catch (Exception e)
            {
                return Content(e.Message);
            }

            return RedirectToAction("ficheros");
        }

        public IActionResult UploadFile2()
        {
            try
            {
                var cn = config.GetSection("AzureStorageConnectionString").Value;

                BlobServiceClient blobClientService = new BlobServiceClient(cn);

                BlobContainerClient containerClient = blobClientService.GetBlobContainerClient("upload");
                if (!containerClient.Exists()) containerClient = blobClientService.CreateBlobContainer("upload");

                BlobClient blobClient = containerClient.GetBlobClient(UploadFileContent.FileName);
                blobClient.Upload(UploadFileContent.OpenReadStream());

                return RedirectToAction("ficheros");
            }
            catch (Exception ex)
            {
                return Content(ex.Message);
            }
        }
    }
}
