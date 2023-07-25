using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Boleto.Domain.Models;
using Boleto.Infrastructure.Services.Interfaces;
using Boleto.Domain.SwaggerModels;

namespace Boleto.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class BoletoController : ControllerBase
    {
        private readonly IBoletoService _boletoService;
        //private readonly IProducer<string, string> _kafkaProducer;

        public BoletoController(IBoletoService boletoService
            //, IProducer<string, string> kafkaProducer
            )
        {
            _boletoService = boletoService;
            //_kafkaProducer = kafkaProducer;
        }

        [HttpGet]
        public async Task<ActionResult<List<BoletoModel>>> GetAll()
        {
            List<BoletoModel> boletos = await _boletoService.GetAll();
            
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
    }
}