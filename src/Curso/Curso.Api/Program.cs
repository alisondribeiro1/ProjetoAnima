using Curso.Infrastructure.Data;
using Curso.Infrastructure.Repositorios;
using Curso.Infrastructure.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Curso.Api
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

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("PostgreSQLConnection");
            builder.Services.AddDbContext<CursoDbContext>(options =>
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Curso.Api")));

            builder.Services.AddScoped<ICursoRepositorio, CursoRepositorio>();
            builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            builder.Services.AddScoped<ICursoOfertaRepositorio, CursoOfertaRepositorio>();
            builder.Services.AddScoped<IModeloRepositorio, ModeloRepositorio>();
            builder.Services.AddScoped<ITurnoRepositorio, TurnoRepositorio>();

            var app = builder.Build();

          
            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}