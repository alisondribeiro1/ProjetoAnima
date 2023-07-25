using Curso.Domain.Models;
using Curso.Domain.Requests;
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
        public async Task<CursoModel> Adicionar(CursoRequest cursoRequest)
        {
            CursoModel cursoModel = new CursoModel
            {
                Nome = cursoRequest.Nome,
                Descricao = cursoRequest.Descricao,
                CargaHoraria = cursoRequest.CargaHoraria
            };

            await _cursoDbContext.Cursos.AddAsync(cursoModel);
            await _cursoDbContext.SaveChangesAsync();

            return cursoModel;
        }
        public async Task<CursoModel> Atualizar(CursoRequest cursoRequest, int idCurso)
        {
            CursoModel cursoPorId = await BuscarCursoPorId(idCurso);

            if (cursoPorId == null)
            {
                throw new Exception($"Curso não encontrado. Id: {idCurso}");
            }

            cursoPorId.Nome = cursoRequest.Nome;
            cursoPorId.Descricao = cursoRequest.Descricao;
            cursoPorId.CargaHoraria = cursoRequest.CargaHoraria;

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
