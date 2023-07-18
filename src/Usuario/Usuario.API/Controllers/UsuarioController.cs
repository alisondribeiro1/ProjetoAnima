using Microsoft.AspNetCore.Mvc;
using Usuario.Domain.Models;
using Usuario.Infrastructure.Repositories.Interfaces;
using Alunos.Domain.Validations;

namespace Usuario.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModel>>> GetAll()
        {
            List<UsuarioModel> usuarios = await _usuarioRepository.GetAll();
            return Ok(usuarios);
        }

        [HttpGet("{idusuario}")]
        public async Task<ActionResult<UsuarioModel>> GetById(int idusuario)
        {
            UsuarioModel usuario = await _usuarioRepository.GetById(idusuario);
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult<UsuarioModel>> Create([FromBody]UsuarioModel usuarioModel)
        {
            if (!CPFValidator.Validate(usuarioModel.CPF))
            {
                return BadRequest("CPF inválido!");
            }

            UsuarioModel usuario = await _usuarioRepository.Create(usuarioModel);
            return Ok(usuario);
        }
        
        [HttpPut("{idusuario}")]
        public async Task<ActionResult<UsuarioModel>> Update([FromBody] UsuarioModel usuarioModel, int idusuario)
        {
            if (!CPFValidator.Validate(usuarioModel.CPF))
            {
                return BadRequest("CPF inválido!");
            }

            UsuarioModel usuario = await _usuarioRepository.Update(usuarioModel, idusuario);
            return Ok(usuario);
        }

        [HttpDelete("{idusuario}")]
        public async Task<ActionResult<UsuarioModel>> DeleteById(int idusuario)
        {
            bool deleted = await _usuarioRepository.DeleteById(idusuario);
            return Ok(deleted);
        }
    }
}