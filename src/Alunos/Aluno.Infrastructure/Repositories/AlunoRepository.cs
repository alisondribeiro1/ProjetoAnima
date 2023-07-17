using Microsoft.EntityFrameworkCore;
using Aluno.Infrastructure.Data;
using Aluno.Domain.Models;
using Aluno.Infrastructure.Repositories.Interfaces;


namespace Aluno.Infrastructure.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AlunoDbContext _dbContext;

        public AlunoRepository(AlunoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<AlunoModel>> GetAll()
        {
            return await _dbContext.Alunos.ToListAsync();
        }

        public async Task<AlunoModel> GetById(int id)
        {
            return await _dbContext.Alunos.FirstOrDefaultAsync(a => a.Id == id);
        }

        public async Task<AlunoModel> Create(AlunoModel aluno)
        {
            await _dbContext.Alunos.AddAsync(aluno);
            await _dbContext.SaveChangesAsync();

            return aluno;   
        }

        public async Task<AlunoModel> Update(AlunoModel aluno, int id)
        {
            AlunoModel alunoExistente = await GetById(id);
            if (alunoExistente == null)
            {
                throw new Exception($"Aluno para o ID: {id} não foi encontrado no banco de dados.");   
            }

            alunoExistente.Nome = aluno.Nome;

            _dbContext.Alunos.Update(alunoExistente);
            await _dbContext.SaveChangesAsync();

            return alunoExistente;
        }

        public async Task<bool> DeleteById(int id)
        {
            AlunoModel alunoExistente = await GetById(id);
            if (alunoExistente == null)
            {
                throw new Exception($"Aluno para o ID: {id} não foi encontrado no banco de dados.");
            }
            
            _dbContext.Alunos.Remove(alunoExistente);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
