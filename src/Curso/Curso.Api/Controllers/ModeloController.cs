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
    public class ModeloController : ControllerBase
    {
        private readonly IModeloRepositorio _modeloRepositorio;
        public ModeloController(IModeloRepositorio modeloRepositorio)
        {
            _modeloRepositorio = modeloRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<ModeloModel>>> BuscarTodosModelos()
        {
            List<ModeloModel> modelos = await _modeloRepositorio.BuscarTodosModelos();
            return Ok(modelos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ModeloModel>> BuscarModeloPorId(int id)
        {
            ModeloModel modelo = await _modeloRepositorio.BuscarModeloPorId(id);
            return Ok(modelo);
        }

        [HttpPost]
        public async Task<ActionResult<ModeloModel>> Adicionar([FromBody] ModeloRequest modeloRequest)
        {
            ModeloModel modeloModel = await _modeloRepositorio.Adicionar(modeloRequest);
            return Ok(modeloModel);
        }

        [HttpPut("id")]
        public async Task<ActionResult<ModeloModel>> Atualizar([FromBody] ModeloRequest modeloRequest, int id)
        {

            ModeloModel ModeloModel = await _modeloRepositorio.Atualizar(modeloRequest, id);
            return Ok(ModeloModel);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<ModeloModel>> Apagar(int id)
        {
            bool apagado = await _modeloRepositorio.Apagar(id);
            return Ok(apagado);
        }
    }
}
