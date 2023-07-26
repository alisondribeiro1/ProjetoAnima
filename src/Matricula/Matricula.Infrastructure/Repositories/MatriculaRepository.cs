using Microsoft.EntityFrameworkCore;
using Matricula.Infrastructure.Data;
using Matricula.Domain.Models;
using Matricula.Infrastructure.Repositories.Interfaces;


namespace Matricula.Infrastructure.Repositories
{
    public class MatriculaRepository : IMatriculaRepository
    {
        private readonly MatriculaDbContext _dbContext;

        public MatriculaRepository(MatriculaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<MatriculaModel>> GetAll()
        {
            return await _dbContext.Matriculas.ToListAsync();
        }

        public async Task<MatriculaModel> GetById(int idmatricula)
        {
            return await _dbContext.Matriculas.FirstOrDefaultAsync(a => a.IdMatricula == idmatricula);
        }

        public async Task<MatriculaModel> Create(MatriculaModel matricula)
        {
            await _dbContext.Matriculas.AddAsync(matricula);
            await _dbContext.SaveChangesAsync();

            return matricula;   
        }

        public async Task<MatriculaModel> Update(MatriculaModel matricula, int idmatricula)
        {
            MatriculaModel matriculaExistente = await GetById(idmatricula);
            if (matriculaExistente == null)
            {
                throw new Exception($"Usuário para o ID: {idmatricula} não foi encontrado no banco de dados.");   
            }

            matriculaExistente.IdMatricula = matricula.IdMatricula;
            matriculaExistente.IdCurso = matricula.IdCurso;
            matriculaExistente.IdUsuario = matricula.IdUsuario;
            matriculaExistente.Ativo = matricula.Ativo;
            matriculaExistente.Aprovado = matricula.Aprovado;


            _dbContext.Matriculas.Update(matriculaExistente);
            await _dbContext.SaveChangesAsync();

            return matriculaExistente;
        }

        public async Task<bool> DeleteById(int idmatricula)
        {
            MatriculaModel matriculaExistente = await GetById(idmatricula);
            if (matriculaExistente == null)
            {
                throw new Exception($"Usuario para o ID: {idmatricula} não foi encontrado no banco de dados.");
            }
            
            _dbContext.Matriculas.Remove(matriculaExistente);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
