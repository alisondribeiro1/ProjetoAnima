using Curso.Domain.Models;
using Curso.Infrastructure.Data;
using Curso.Infrastructure.Repositorios.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Infrastructure.Repositorios
{
    public class CursoRepositorio : ICursoRepositorio
    {
        private readonly CursoDbContext _cursoDbContext;
        public CursoRepositorio(CursoDbContext cursoDbContext)
        {
            _cursoDbContext = cursoDbContext;
        }
        public async Task<CursoModel> BuscarCursoPorId(int idCurso)
        {
            return await _cursoDbContext.Cursos.FirstOrDefaultAsync(x => x.idCurso == idCurso);
        }

        public async Task<List<CursoModel>> BuscarTodosCursos()
        {
            return await _cursoDbContext.Cursos.ToListAsync();
        }
        public async Task<CursoModel> Adicionar(CursoModel curso)
        {
            await _cursoDbContext.Cursos.AddAsync(curso);
            await _cursoDbContext.SaveChangesAsync();

            return curso;
        }
        public async Task<CursoModel> Atualizar(CursoModel curso, int idCurso)
        {
            CursoModel cursoPorId = await BuscarCursoPorId(idCurso);

            if (cursoPorId == null)
            {
                throw new Exception($"Curso não encontrado. Id: {idCurso}");
            }

            cursoPorId.idCurso = curso.idCurso;
            cursoPorId.Nome = curso.Nome;
            cursoPorId.Descricao = curso.Descricao;
            cursoPorId.CargaHoraria = curso.CargaHoraria;

            _cursoDbContext.Cursos.Update(cursoPorId);
            await _cursoDbContext.SaveChangesAsync();

            return cursoPorId;
        }

        public async Task<bool> Apagar(int idCurso)
        {
            CursoModel cursoPorId = await BuscarCursoPorId(idCurso);

            if (cursoPorId == null)
            {
                throw new Exception($"Curso não encontrado. Id: {idCurso}");
            }

            _cursoDbContext.Cursos.Remove(cursoPorId);
            await _cursoDbContext.SaveChangesAsync();
            return true;
        }

    }
}
