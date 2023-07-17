using Aluno.Infrastructure.Data;
using Aluno.Infrastructure.Repositories;
using Aluno.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Aluno.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            var connectionString = configuration.GetConnectionString("PostgreSQLConnection");

            builder.Services.AddDbContext<AlunoDbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Aluno.API")));

            builder.Services.AddScoped<IAlunoRepository, AlunoRepository>();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          

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