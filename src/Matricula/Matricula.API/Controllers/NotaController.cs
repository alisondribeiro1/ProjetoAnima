using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Nota.Domain.Models;
using Nota.Infrastructure.Repositories.Interfaces;
using System.Text.Json;

namespace Nota.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class NotaController : ControllerBase
    {
        private readonly INotaRepository _notaRepository;
        //private readonly IProducer<string, string> _kafkaProducer;

        public NotaController(INotaRepository notaRepository) //, IProducer<string, string> kafkaProducer
        {
            _notaRepository = notaRepository;
            //_kafkaProducer = kafkaProducer;
        }

        [HttpGet]
        public async Task<ActionResult<List<NotaModel>>> GetAll()
        {
            List<NotaModel> Notas = await _notaRepository.GetAll();
            
            // Enviar mensagem para o Kafka
            //string json = JsonSerializer.Serialize(Notas);

            //await _kafkaProducer.ProduceAsync("topico-Nota", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });

            return Ok(Notas);
        }

        [HttpGet("{idNota}")]
        public async Task<ActionResult<NotaModel>> GetById(int idNota)
        {
            NotaModel Nota = await _notaRepository.GetById(idNota);
            
            // Enviar mensagem para o Kafka
            //string json = JsonSerializer.Serialize(Nota);

            //await _kafkaProducer.ProduceAsync("topico-Nota", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });
            
            return Ok(Nota);
        }

        [HttpPost]
        public async Task<ActionResult<NotaModel>> Create([FromBody]NotaModel notaModel)
        {
            if (notaModel.IdMatricula == 0)
            {
                return BadRequest("ID do Matricula inválido!");
            }

            var calmedia = (notaModel.Nota1 + notaModel.Nota1 + notaModel.Nota3)/3;

            if (calmedia == notaModel.Media || calmedia == 0)
            {
                NotaModel Nota = await _notaRepository.Create(notaModel);
            
                // Enviar mensagem para o Kafka
                //string json = JsonSerializer.Serialize(Nota);

                //await _kafkaProducer.ProduceAsync("topico-Nota", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });
                
                return Ok(Nota);
            }

            return BadRequest("A média informada está incorreta!");
        }
        
        [HttpPut("{idNota}")]
        public async Task<ActionResult<NotaModel>> Update([FromBody] NotaModel notaModel, int idNota)
        {
            if (notaModel.IdMatricula == 0)
            {
                return BadRequest("ID da matrícula inválido!");
            }

            NotaModel Nota = await _notaRepository.Update(notaModel, idNota);
            
            // Enviar mensagem para o Kafka
            //string json = JsonSerializer.Serialize(Nota);

            //await _kafkaProducer.ProduceAsync("topico-Nota", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });
            
            return Ok(Nota);
        }

        [HttpDelete("{idNota}")]
        public async Task<ActionResult<NotaModel>> DeleteById(int idNota)
        {
            bool deleted = await _notaRepository.DeleteById(idNota);
            
            // Enviar mensagem para o Kafka
            //string json = JsonSerializer.Serialize(deleted);

            //await _kafkaProducer.ProduceAsync("topico-Nota", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });
            
            return Ok(deleted);
        }
    }
}