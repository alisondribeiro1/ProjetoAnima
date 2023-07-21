using Cursos.Contexto;
using Cursos.Repositorios;
using Cursos.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cursos
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            /*builder.Services.AddEntityFrameworkNpgsql()
                .AddDbContext<CursoDbContext>(
                    options => options.UseNpgsql(builder.Configuration
                    .GetConnectionString("PostgreSQLConnection")));*/

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("PostgreSQLConnection");
            builder.Services.AddDbContext<CursoDbContext>(options =>
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Cursos")));

            builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}