namespace Azure.AppService.WebJobs.ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine($">> PROCESO INICIADO {DateTime.Now}");
            try
            {
                var ficheros = Directory.GetFiles(@"D:\home\site\wwwroot\wwwroot\upload");
                Console.WriteLine($">>>> {ficheros.Length} encontrados.");
                foreach (var ruta in ficheros)
                {
                    var fichero = new FileInfo(ruta);
                    Console.WriteLine($">>>>>> {fichero.FullName}");
                    File.Move(fichero.FullName, @"D:\home\site\wwwroot\wwwroot\process\" + fichero.Name);
                    Console.WriteLine($">>>>>> P R O C E S A D O");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($">> ERROR: {ex.Message}");
            }

            Console.WriteLine($">> PROCESO FINALIZADO {DateTime.Now}");
        }
    }
}
