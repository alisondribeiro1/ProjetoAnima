using Microsoft.AspNetCore.Mvc;
using Aluno.Domain.Models;
using Aluno.Infrastructure.Repositories.Interfaces;

namespace Aluno.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AlunoController : ControllerBase
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoController(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        [HttpGet]
        public async Task<ActionResult<List<AlunoModel>>> GetAll()
        {
            List<AlunoModel> alunos = await _alunoRepository.GetAll();
            return Ok(alunos);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<AlunoModel>> GetById(int id)
        {
            AlunoModel aluno = await _alunoRepository.GetById(id);
            return Ok(aluno);
        }

        [HttpPost]
        public async Task<ActionResult<AlunoModel>> Create([FromBody]AlunoModel alunoModel)
        {
            AlunoModel aluno = await _alunoRepository.Create(alunoModel);
            return Ok(aluno);
        }
        
        [HttpPut("{id}")]
        public async Task<ActionResult<AlunoModel>> Update([FromBody] AlunoModel alunoModel, int id)
        {
            alunoModel.Id = id;
            AlunoModel aluno = await _alunoRepository.Update(alunoModel, id);
            return Ok(aluno);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<AlunoModel>> DeleteById(int id)
        {
            bool deleted = await _alunoRepository.DeleteById(id);
            return Ok(deleted);
        }
    }
}