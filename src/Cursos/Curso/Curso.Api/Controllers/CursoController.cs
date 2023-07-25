using Curso.Domain.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Curso.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CursoController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<CursoModel>> BuscarTodosCursos()
        {
            return Ok();
        }
    }
}
