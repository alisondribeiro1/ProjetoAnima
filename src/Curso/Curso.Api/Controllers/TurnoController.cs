using Curso.Domain.Models;
using Curso.Domain.Requests;
using Curso.Infrastructure.Repositorios;
using Curso.Infrastructure.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TurnoController : ControllerBase
    {
        private readonly ITurnoRepositorio _turnoRepositorio;
        public TurnoController(ITurnoRepositorio turnoRepositorio)
        {
            _turnoRepositorio = turnoRepositorio;
        }

        /// <summary>
        /// Busca o Turno através do Id
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<TurnoModel>>> BuscarTodosTurnos()
        {
            List<TurnoModel> turnos = await _turnoRepositorio.BuscarTodosTurnos();
            return Ok(turnos);
        }

        /// <summary>
        /// Retorna Turno por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<TurnoModel>> BuscarTurnoPorId(int id)
        {
            TurnoModel turno = await _turnoRepositorio.BuscarTurnoPorId(id);
            return Ok(turno);
        }

        /// <summary>
        /// Adiciona um Turno
        /// </summary>
        /// <param name="categoriaRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<TurnoModel>> Adicionar([FromBody] TurnoRequest turnoRequest)
        {
            TurnoModel turnoModel = await _turnoRepositorio.Adicionar(turnoRequest);
            return Ok(turnoModel);
        }

        /// <summary>
        /// Atualiza o turno informando Id
        /// </summary>
        /// <param name="categoriaRequest"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<ActionResult<TurnoModel>> Atualizar([FromBody] TurnoRequest turnoRequest, int id)
        {
            TurnoModel turnoModel = await _turnoRepositorio.Atualizar(turnoRequest, id);
            return Ok(turnoModel);
        }

        /// <summary>
        /// Apagar a turno através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<ActionResult<TurnoModel>> Apagar(int id)
        {
            bool apagado = await _turnoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
