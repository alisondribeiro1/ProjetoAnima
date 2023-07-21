using Confluent.Kafka;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using Usuario.Domain.Models;
using Usuario.Infrastructure.Services.Interfaces;

namespace Usuario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IProducer<string, string> _kafkaProducer;

        public UsuarioController(IUsuarioService usuarioService, IProducer<string, string> kafkaProducer)
        {
            _usuarioService = usuarioService;
            _kafkaProducer = kafkaProducer;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> GetAll()
        {
            List<UsuarioModel> usuarios = await _usuarioService.GetAll();
            
            // Enviar mensagem para o Kafka
            string json = JsonSerializer.Serialize(usuarios);

            await _kafkaProducer.ProduceAsync("topico-usuario", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });

            return Ok(usuarios);
        }

        [HttpGet("{idusuario}")]
        public async Task<ActionResult<UsuarioModel>> GetById(int idusuario)
        {
            UsuarioModel usuario = await _usuarioService.GetById(idusuario);

            // Enviar mensagem para o Kafka
            string json = JsonSerializer.Serialize(usuario);

            await _kafkaProducer.ProduceAsync("topico-usuario", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });

            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Create([FromBody]UsuarioModel usuarioModel)
        {
            UsuarioModel usuario = await _usuarioService.Create(usuarioModel);

            // Enviar mensagem para o Kafka
            string json = JsonSerializer.Serialize(usuario);

            await _kafkaProducer.ProduceAsync("topico-usuario", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });


            return Ok(usuario);
        }
        
        [HttpPut("{idusuario}")]
        public async Task<ActionResult<UsuarioModel>> Update([FromBody] UsuarioModel usuarioModel, int idusuario)
        {
            UsuarioModel usuario = await _usuarioService.Update(usuarioModel, idusuario);

            // Enviar mensagem para o Kafka
            string json = JsonSerializer.Serialize(usuario);

            await _kafkaProducer.ProduceAsync("topico-usuario", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });

            return Ok(usuario);
        }

        [HttpDelete("{idusuario}")]
        public async Task<ActionResult<UsuarioModel>> DeleteById(int idusuario)
        {
            bool deleted = await _usuarioService.DeleteById(idusuario);

            // Enviar mensagem para o Kafka
            string json = JsonSerializer.Serialize(deleted);

            await _kafkaProducer.ProduceAsync("topico-usuario", new Message<string, string> { Key = Guid.NewGuid().ToString(), Value = json });

            return Ok(deleted);
        }
    }
}