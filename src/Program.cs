using Microsoft.AspNetCore.Hosting;

namespace HomeworkOrganiser.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IWebHost host = new WebHostBuilder()
                .UseKestrel()
                .UseStartup<Program>()
                .Build();
                
            host.Run();
        }
    }
}
