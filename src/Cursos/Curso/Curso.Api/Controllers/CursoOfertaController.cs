using Curso.Domain.Responses;
using Curso.Infrastructure.Repositorios.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoOfertaController : ControllerBase
    {
        private readonly ICursoOfertaRepositorio _cursoOfertaRepositorio;
        public CursoOfertaController(ICursoOfertaRepositorio cursoOfertaRepositorio)
        {
            _cursoOfertaRepositorio = cursoOfertaRepositorio;
        }

        /// <summary>
        /// Buscar a lista de cursos ofertas com as descrições dos ids
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<CursoOfertaResponse>>> BuscarTodosCursosOfertas()
        {
            List<CursoOfertaResponse> cursosOfertas = await _cursoOfertaRepositorio.BuscarTodosCursosOfertas();
            return Ok(cursosOfertas);
        }
    }
}
