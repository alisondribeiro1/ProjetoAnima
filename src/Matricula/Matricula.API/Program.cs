using Matricula.Infrastructure.Data;
using Matricula.Infrastructure.Repositories;
using Matricula.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Matricula.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}