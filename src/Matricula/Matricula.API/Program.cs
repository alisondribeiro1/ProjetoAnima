using Matricula.Infrastructure.Data;
using Matricula.Infrastructure.Repositories;
using Matricula.Infrastructure.Repositories.Interfaces;
using Matricula.Infrastructure.Services;
using Matricula.Infrastructure.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Matricula.API
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
            builder.Services.AddDbContext<MatriculaDbContext>(options =>
            options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Matricula.API")));

            builder.Services.AddScoped<IMatriculaRepository, MatriculaRepository>();
            builder.Services.AddScoped<IMatriculaService, MatriculaService>();
            //builder.Services.AddScoped<ICategoriaRepositorio, CategoriaRepositorio>();
            //builder.Services.AddScoped<ICursoOfertaRepositorio, CursoOfertaRepositorio>();
            //builder.Services.AddScoped<IModeloRepositorio, ModeloRepositorio>();
            //builder.Services.AddScoped<ITurnoRepositorio, TurnoRepositorio>();

            var app = builder.Build();

          
            app.UseSwagger();
            app.UseSwaggerUI();

            //app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}