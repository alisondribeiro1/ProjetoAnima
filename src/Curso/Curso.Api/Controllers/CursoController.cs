using Curso.Domain.Models;
using Curso.Domain.Requests;
using Curso.Infrastructure.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        private readonly ICursoRepositorio _cursoRepositorio;
        public CursoController (ICursoRepositorio cursoRepositorio)
        {
            _cursoRepositorio= cursoRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<CursoModel>>> BuscarTodosCursos()
        {
            List<CursoModel> cursos = await _cursoRepositorio.BuscarTodosCursos();
            return Ok(cursos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<CursoModel>> BuscarCursoPorId(int id)
        {
            CursoModel curso = await _cursoRepositorio.BuscarCursoPorId(id);
            return Ok(curso);
        }

        [HttpPost]
        public async Task<ActionResult<CursoModel>> Adicionar([FromBody] CursoRequest cursoRequest)
        {
            CursoModel curso = await _cursoRepositorio.Adicionar(cursoRequest);
            return Ok(curso);
        }

        [HttpPut("id")]
        public async Task<ActionResult<CursoModel>> Atualizar([FromBody] CursoRequest cursoRequest, int id)
        {
            //cursoModel.idCurso = id;
            CursoModel curso = await _cursoRepositorio.Atualizar(cursoRequest, id);
            return Ok(curso);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<CursoModel>> Apagar(int id)
        {
            bool apagado = await _cursoRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
