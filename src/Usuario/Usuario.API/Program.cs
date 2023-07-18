using Usuario.Infrastructure.Data;
using Usuario.Infrastructure.Repositories;
using Usuario.Infrastructure.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Usuario.API
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

            builder.Services.AddDbContext<UsuarioDbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Usuario.API")));

            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();


            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
          

            var app = builder.Build();
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            //  Configure the HTTP request pipeline.
            //   if (app.Environment.IsDevelopment())
            // {
            app.UseSwagger();
                app.UseSwaggerUI();

            //    app.UseHttpsRedirection();
           // }

            

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}