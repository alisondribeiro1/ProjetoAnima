using Confluent.Kafka;
using Microsoft.EntityFrameworkCore;
using Boleto.Infrastructure.Data;
using Boleto.Infrastructure.Repositories.Interfaces;
using Boleto.Infrastructure.Repositories;
using Boleto.Infrastructure.Services.Interfaces;
using Boleto.Infrastructure.Services;

namespace Boleto.API
{
    public class Startup
    {
        // Construtor e outras propriedades omitidas para brevidade

        public void ConfigureServices(IServiceCollection services)
        {
            IConfiguration configuration = new ConfigurationBuilder()
                .SetBasePath(AppDomain.CurrentDomain.BaseDirectory)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // Configurações do PostgreSQL
            var connectionString = configuration.GetConnectionString("PostgreSQLConnection");

            services.AddDbContext<BoletoDbContext>(options =>
                options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Boleto.API")));

            // Registro do serviço IProducer<string, string>
            services.AddSingleton<IProducer<string, string>>(provider =>
            {
                var config = new ProducerConfig
                {
                    BootstrapServers = "localhost:9092",
                    // Outras configurações do produtor, se necessário
                };
                return new ProducerBuilder<string, string>(config).Build();
            });

            // Outros serviços e configurações adicionais
            services.AddScoped<IBoletoService, BoletoService>();
            services.AddScoped<IBoletoRepository, BoletoRepository>();
            services.AddHttpClient();

            // Configurar os controllers da API
            services.AddControllers();

            // Configuração do Swagger
            services.AddSwaggerGen();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            // Configuração do comportamento de timestamp legado do Npgsql
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

            // Habilitar o Swagger como um middleware
            app.UseSwagger();

            app.UseSwaggerUI();

            // Configurar o uso de roteamento para os controllers da API
            app.UseRouting();

            // Configurar a autorização, autenticação ou outras políticas, se necessário
            // app.UseAuthorization();

            // Configurar os endpoints dos controllers da API
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

        }
    }
}

