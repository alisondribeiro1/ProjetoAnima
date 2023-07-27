using Microsoft.EntityFrameworkCore;
using Matricula.Infrastructure.Data;
using Matricula.Domain.Models;
using Nota.Domain.Models;
using Matricula.Infrastructure.Repositories.Interfaces;
using Nota.Infrastructure.Repositories.Interfaces;


namespace Nota.Infrastructure.Repositories
{
    public class NotaRepository : INotaRepository
    {
        private readonly MatriculaDbContext _dbContext;

        public NotaRepository(MatriculaDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<NotaModel>> GetAll()
        {
            return await _dbContext.Notas.ToListAsync();
        }

        public async Task<NotaModel> GetById(int idMatricula)
        {
            return await _dbContext.Notas.FirstOrDefaultAsync(a => a.IdMatricula == idMatricula);
        }

        public async Task<NotaModel> Create(NotaModel nota)
        {
            await _dbContext.Notas.AddAsync(nota);
            await _dbContext.SaveChangesAsync();

            return nota;   
        }

        public async Task<NotaModel> Update(NotaModel nota, int idMatricula)
        {
            NotaModel notasExistentes = await GetById(idMatricula);
            if (notasExistentes == null)
            {
                throw new Exception($"Usuário para o ID: {idMatricula} não foi encontrado no banco de dados.");   
            }

            notasExistentes.IdNota = nota.IdNota;
            notasExistentes.IdMatricula = nota.IdMatricula;
            notasExistentes.Nota1 = nota.Nota1;
            notasExistentes.Nota2 = nota.Nota2;
            notasExistentes.Nota3 = nota.Nota3;


            _dbContext.Notas.Update(notasExistentes);
            await _dbContext.SaveChangesAsync();

            return notasExistentes;
        }

        public async Task<bool> DeleteById(int idMatricula)
        {
            NotaModel notasExistentes = await GetById(idMatricula);
            if (notasExistentes == null)
            {
                throw new Exception($"Usuario para o ID: {idMatricula} não foi encontrado no banco de dados.");
            }
            
            _dbContext.Notas.Remove(notasExistentes);
            await _dbContext.SaveChangesAsync();

            return true;
        }

    }
}
