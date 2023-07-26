using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Boleto.Domain.Models;
using Boleto.Infrastructure.Services.Interfaces;
using Boleto.Domain.SwaggerModels;
using System.Net.Http;
using Boleto.Infrastructure.Services.Request;

namespace Boleto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletoController : ControllerBase
    {
        private readonly IBoletoService _boletoService;
        //private readonly IProducer<string, string> _kafkaProducer;
        private readonly IHttpClientFactory _httpClientFactory;


        public BoletoController(IBoletoService boletoService,
            //, IProducer<string, string> kafkaProducer,
            IHttpClientFactory httpClientFactory
            )
        {
            _boletoService = boletoService;
            //_kafkaProducer = kafkaProducer;
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<ActionResult<List<BoletoModel>>> GetAll()
        {
            List<BoletoModel> boletos = await _boletoService.GetAll();

            Console.WriteLine("Retornando get all");
            
            // Enviar mensagem para o Kafka
            //string json = JsonSerializer.Serialize(boletos);

            //await _kafkaProducer.ProduceAsync("topico-boleto", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });

            return Ok(boletos);
        }

        [HttpGet("idMatricula")]
        public async Task<ActionResult<List<BoletoModel>>> GetAllByMatricula(int idMatricula)
        {
            List<BoletoModel> boletos = await _boletoService.GetAllByMatricula(idMatricula);

            // Enviar mensagem para o Kafka
            //string json = JsonSerializer.Serialize(boletos);

            //await _kafkaProducer.ProduceAsync("topico-boleto", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });

            return Ok(boletos);
        }

        [HttpGet("idBoleto")]
        public async Task<ActionResult<BoletoModel>> GetById(int idBoleto)
        {
            BoletoModel boleto = await _boletoService.GetById(idBoleto);

            // Enviar mensagem para o Kafka
            //string json = JsonSerializer.Serialize(boleto);

            //await _kafkaProducer.ProduceAsync("topico-boleto", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });

            return Ok(boleto);
        }

        [HttpPost]
        public async Task<ActionResult<BoletoModel>> Create([FromBody] BoletoSwagger boletoModel)
        {
            BoletoModel boleto = await _boletoService.Create(boletoModel);

            // Enviar mensagem para o Kafka
            //string json = JsonSerializer.Serialize(boleto);

            //await _kafkaProducer.ProduceAsync("topico-boleto", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });


            return Ok(boleto);
        }
        
        [HttpPut("idBoleto")]
        public async Task<ActionResult<bool>> Update([FromBody] BoletoModel boletoModel, int idBoleto)
        {
            bool boleto = await _boletoService.Update(boletoModel, idBoleto);

            // Enviar mensagem para o Kafka
            //string json = JsonSerializer.Serialize(boleto);

            //await _kafkaProducer.ProduceAsync("topico-boleto", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });

            return Ok(boleto);
        }

        [HttpDelete("idBoleto")]
        public async Task<ActionResult<bool>> DeleteById(int idBoleto)
        {
            bool deleted = await _boletoService.DeleteById(idBoleto);

            // Enviar mensagem para o Kafka
            //string json = JsonSerializer.Serialize(deleted);

            //await _kafkaProducer.ProduceAsync("topico-boleto", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });

            return Ok(deleted);
        }

        [HttpGet("download-boleto/{guid}")]
        public async Task<IActionResult> DownloadBoleto(Guid guid)
        {
            var httpClient = _httpClientFactory.CreateClient();
                        
            string urlFinanceiro = $"https://localhost:5001/api/Exemplo/download-boleto/{guid}";

            HttpResponseMessage response;

            try
            {
                response = await httpClient.GetAsync(urlFinanceiro);
                response.EnsureSuccessStatusCode();
            }
            catch (HttpRequestException e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, $"Erro: {e}");
            }

            byte[] pdfContent = await response.Content.ReadAsByteArrayAsync();

            // Enviar mensagem para o Kafka
            //string json = JsonSerializer.Serialize(deleted);

            //await _kafkaProducer.ProduceAsync("topico-boleto", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });

            return File(pdfContent, "application/pdf", $"boleto-{guid}.pdf");
        }
    }
}