using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using Matricula.Domain.Models;
using Matricula.Infrastructure.Repositories.Interfaces;
using System.Text.Json;

namespace Matricula.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class MatriculaController : ControllerBase
    {
        private readonly IMatriculaRepository _matriculaRepository;
        private readonly IProducer<string, string> _kafkaProducer;

        public MatriculaController(IMatriculaRepository matriculaRepository, IProducer<string, string> kafkaProducer)
        {
            _matriculaRepository = matriculaRepository;
            _kafkaProducer = kafkaProducer;
        }

        [HttpGet]
        public async Task<ActionResult<List<MatriculaModel>>> GetAll()
        {
            List<MatriculaModel> matriculas = await _matriculaRepository.GetAll();
            
            // Enviar mensagem para o Kafka
            string json = JsonSerializer.Serialize(matriculas);

            await _kafkaProducer.ProduceAsync("topico-matricula", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });

            return Ok(matriculas);
        }

        [HttpGet("{idmatricula}")]
        public async Task<ActionResult<MatriculaModel>> GetById(int idmatricula)
        {
            MatriculaModel matricula = await _matriculaRepository.GetById(idmatricula);
            
            // Enviar mensagem para o Kafka
            string json = JsonSerializer.Serialize(matricula);

            await _kafkaProducer.ProduceAsync("topico-matricula", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });
            
            return Ok(matricula);
        }

        [HttpPost]
        public async Task<ActionResult<MatriculaModel>> Create([FromBody]MatriculaModel matriculaModel)
        {
            if (matriculaModel.IdUsuario == 0)
            {
                return BadRequest("ID do usuário inválido!");
            }

            MatriculaModel matricula = await _matriculaRepository.Create(matriculaModel);
            
            // Enviar mensagem para o Kafka
            string json = JsonSerializer.Serialize(matricula);

            await _kafkaProducer.ProduceAsync("topico-matricula", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });
            
            return Ok(matricula);
        }
        
        [HttpPut("{idmatricula}")]
        public async Task<ActionResult<MatriculaModel>> Update([FromBody] MatriculaModel matriculaModel, int idMatricula)
        {
            if (matriculaModel.IdUsuario == 0)
            {
                return BadRequest("ID do usuário inválido!");
            }

            MatriculaModel matricula = await _matriculaRepository.Update(matriculaModel, idMatricula);
            
            // Enviar mensagem para o Kafka
            string json = JsonSerializer.Serialize(matricula);

            await _kafkaProducer.ProduceAsync("topico-matricula", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });
            
            return Ok(matricula);
        }

        [HttpDelete("{idmatricula}")]
        public async Task<ActionResult<MatriculaModel>> DeleteById(int idmatricula)
        {
            bool deleted = await _matriculaRepository.DeleteById(idmatricula);
            
            // Enviar mensagem para o Kafka
            string json = JsonSerializer.Serialize(deleted);

            await _kafkaProducer.ProduceAsync("topico-matricula", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });
            
            return Ok(deleted);
        }
    }
}