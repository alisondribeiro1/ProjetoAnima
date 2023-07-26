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
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoriaRepositorio _categoriaRepositorio;
        public CategoriaController(ICategoriaRepositorio categoriaRepositorio)
        {
            _categoriaRepositorio = categoriaRepositorio;
        }
        /// <summary>
        /// Retorna todas as categorias
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public async Task<ActionResult<List<CategoriaModel>>> BuscarTodasCategorias()
        {
            List<CategoriaModel> categorias = await _categoriaRepositorio.BuscarTodasCategorias();
            return Ok(categorias);
        }

        /// <summary>
        /// Retorna Categoria por Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("{id}")]
        public async Task<ActionResult<CategoriaModel>> BuscarCategoriaPorId(int id)
        {
            CategoriaModel categoria = await _categoriaRepositorio.BuscarCategoriaPorId(id);
            return Ok(categoria);
        }

        /// <summary>
        /// Adiciona uma categoria
        /// </summary>
        /// <param name="categoriaRequest"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<ActionResult<CategoriaModel>> Adicionar([FromBody] CategoriaRequest categoriaRequest)
        {
            CategoriaModel categoriaModel = await _categoriaRepositorio.Adicionar(categoriaRequest);
            return Ok(categoriaModel);
        }

        /// <summary>
        /// Atualiza a categoria informado Id
        /// </summary>
        /// <param name="categoriaRequest"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPut("id")]
        public async Task<ActionResult<CategoriaModel>> Atualizar([FromBody] CategoriaRequest categoriaRequest, int id)
        {
            //cursoModel.idCurso = id;
            CategoriaModel categoriaModel = await _categoriaRepositorio.Atualizar(categoriaRequest, id);
            return Ok(categoriaModel);
        }

        /// <summary>
        /// Apagar a categoria através do Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpDelete("id")]
        public async Task<ActionResult<CursoModel>> Apagar(int id)
        {
            bool apagado = await _categoriaRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
