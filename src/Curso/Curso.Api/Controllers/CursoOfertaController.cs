using Curso.Domain.Models;
using Curso.Domain.Requests;
using Curso.Domain.Responses;
using Curso.Infrastructure.Repositorios;
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

        /// <summary>
        /// Buscar curso oferta por Id com as descricoes.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CursoOfertaResponse>> BuscarCursoOfertaPorId(int id)
        {
            CursoOfertaResponse cursoOferta = await _cursoOfertaRepositorio.BuscarCursoOfertaPorId(id);
            return Ok(cursoOferta);
        }

        /// <summary>
        /// Método para adicionar um curso oferta
        /// </summary>
        /// <param name="cursoRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CursoOfertaResponse>> Adicionar([FromBody] CursoOfertaRequest cursoOfertaRequest)
        {
            CursoOfertaResponse cursoOfertaResponse = await _cursoOfertaRepositorio.Adicionar(cursoOfertaRequest.Curso,
                                                                                              cursoOfertaRequest.Categoria,
                                                                                              cursoOfertaRequest.Modelo,
                                                                                              cursoOfertaRequest.Turno);
            return Ok(cursoOfertaResponse);
        }

        /// <summary>
        /// Mètodo para atualizar Curso Oferta
        /// </summary>
        /// <param name="cursoRequest"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<ActionResult<CursoOfertaResponse>> Atualizar([FromBody] CursoOfertaRequest cursoOfertaRequest,
                                                                       int id)
        {
            //cursoModel.idCurso = id;
            CursoOfertaResponse cursoOfertaResponse = await _cursoOfertaRepositorio.Atualizar(cursoOfertaRequest.Curso,
                                                                                              cursoOfertaRequest.Categoria,
                                                                                              cursoOfertaRequest.Modelo,
                                                                                              cursoOfertaRequest.Turno,
                                                                                              id);
            return Ok(cursoOfertaResponse);
        }

        /// <summary>
        /// Metodo para apagar CursoOferta
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<ActionResult<CursoModel>> Apagar(int id)
        {
            bool apagado = await _cursoOfertaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
