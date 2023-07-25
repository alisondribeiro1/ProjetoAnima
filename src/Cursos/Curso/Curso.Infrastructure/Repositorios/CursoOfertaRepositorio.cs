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
    public class CursoOfertaRepositorio : ICursoOfertaRepositorio
    {
        private readonly CursoDbContext _cursoDbContext;
        public CursoOfertaRepositorio(CursoDbContext cursoDbContext)
        {
            _cursoDbContext = cursoDbContext;
        }
        public async Task<CursoOfertaModel> BuscarCursoOfertaPorId(int idCursoOferta)
        {
            return await _cursoDbContext.CursosOfertas.FirstOrDefaultAsync(x => x.IdCursoOferta == idCursoOferta);
        }

        public async Task<List<CursoOfertaModel>> BuscarTodosCursosOfertas()
        {
            return await _cursoDbContext.CursosOfertas.ToListAsync();
        }
      
        public async Task<CursoOfertaModel> Adicionar(CursoOfertaModel cursoOferta)
        {
            await _cursoDbContext.CursosOfertas.AddAsync(cursoOferta);
            await _cursoDbContext.SaveChangesAsync();

            return cursoOferta;
        }
        public async Task<CursoOfertaModel> Atualizar(CursoOfertaModel cursoOferta, int idCursoOferta)
        {
            CursoOfertaModel cursoOfertaPorId = await BuscarCursoOfertaPorId(idCursoOferta);

            if (cursoOfertaPorId == null)
            {
                throw new Exception($"Curso Oferta não encontrado. Id: {idCursoOferta}");
            }

            cursoOfertaPorId.IdCursoOferta = cursoOferta.IdCursoOferta;
            cursoOfertaPorId.IdCurso = cursoOferta.IdCurso;
            cursoOfertaPorId.Curso = cursoOferta.Curso;
            cursoOfertaPorId.IdModelo = cursoOferta.IdModelo;
            cursoOfertaPorId.Modelo = cursoOferta.Modelo;
            cursoOfertaPorId.IdCategoria = cursoOferta.IdCategoria;
            cursoOfertaPorId.Categoria = cursoOferta.Categoria;
            cursoOfertaPorId.IdTurno = cursoOferta.IdTurno;
            cursoOfertaPorId.Turno = cursoOferta.Turno;

            _cursoDbContext.CursosOfertas.Update(cursoOfertaPorId);
            await _cursoDbContext.SaveChangesAsync();

            return cursoOfertaPorId;
        }

        public async Task<bool> Apagar(int idCursoOferta)
        {
            CursoOfertaModel cursoOfertaPorId = await BuscarCursoOfertaPorId(idCursoOferta);

            if (cursoOfertaPorId == null)
            {
                throw new Exception($"Curso Oferta não encontrado. Id: {idCursoOferta}");
            }

            _cursoDbContext.CursosOfertas.Remove(cursoOfertaPorId);
            await _cursoDbContext.SaveChangesAsync();
            return true;
        }
    }
}
