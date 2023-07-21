using Cursos.Contexto;
using Cursos.Models;
using Cursos.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Cursos.Repositorios
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly CursoDbContext _cursoDbContext;
        public CursoRepositorio(CursoDbContext cursoDbContext)
        {
            _cursoDbContext = cursoDbContext;
        }
        public async Task<Curso> BuscarCursoPorId(int id)
        {
            return await _cursoDbContext.Cursos.FirstOrDefaultAsync(x => x.IdCurso == id);
        }
        public async Task<List<Curso>> BuscarTodosCursos()
        {
            return await _cursoDbContext.Cursos.ToListAsync();
        }
        public async Task<Curso> Adicionar(Curso curso)
        {
            await _cursoDbContext.Cursos.AddAsync(curso);
            await _cursoDbContext.SaveChangesAsync();

            return curso;
        }

        public async Task<Curso> Atualizar(Curso curso, int id)
        {
            Curso cursoPorId = await BuscarCursoPorId(id);

            if (cursoPorId == null)
            {
                throw new Exception($"Curso não encontrado. Id: {id}");
            }

            cursoPorId.Turno = curso.Turno;
            cursoPorId.Descricao = curso.Descricao;
            cursoPorId.CargaHoraria = curso.CargaHoraria;
            cursoPorId.Categoria = curso.Categoria;
            cursoPorId.Nome = curso.Nome;
            cursoPorId.Modelo = curso.Modelo;

            _cursoDbContext.Update(cursoPorId);
            await _cursoDbContext.SaveChangesAsync();

            return cursoPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            Curso cursoPorId = await BuscarCursoPorId(id);

            if (cursoPorId == null)
            {
                throw new Exception($"Curso não encontrado. Id: {id}");
            }

            _cursoDbContext.Cursos.Remove(cursoPorId);
            await _cursoDbContext.SaveChangesAsync();
            return true;
        }

    }
}
