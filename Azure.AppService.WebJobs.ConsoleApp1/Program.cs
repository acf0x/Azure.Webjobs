using System.Timers;

namespace Azure.AppService.WebJobs.ConsoleApp1
{
    internal class Program
    {
        private static System.Timers.Timer timer;
        static void Main(string[] args)
        {
            timer = new System.Timers.Timer();
            timer.Interval = 30000;

            timer.Elapsed += Timer_DemoWebJobs;

            timer.AutoReset = true;
            timer.Enabled = true;

            Console.WriteLine($">>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>>> {DateTime.Now}");
            Console.ReadLine();
        }

        private static void Timer_DemoWebJobs(object sender, ElapsedEventArgs e)
        {
            Console.WriteLine($">> PROCESO INICIADO {DateTime.Now}");
            try
            {
                var ficheros = Directory.GetFiles(@"C:\home\site\wwwroot\wwwroot\upload");
                Console.WriteLine($">>>> {ficheros.Length} encontrados.");
                foreach (var ruta in ficheros)
                {
                    var fichero = new FileInfo(ruta);
                    Console.WriteLine($">>>>>> {fichero.FullName}");
                    File.Move(fichero.FullName, @"C:\home\site\wwwroot\wwwroot\process\" + fichero.Name);
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
