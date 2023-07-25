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
    public class TurnoRepositorio : ITurnoRepositorio
    {
        private readonly CursoDbContext _cursoDbContext;
        public TurnoRepositorio(CursoDbContext cursoDbContext)
        {
            _cursoDbContext = cursoDbContext;
        }
        public async Task<TurnoModel> BuscarTurnoPorId(int idTurno)
        {
            return await _cursoDbContext.Turnos.FirstOrDefaultAsync(x => x.IdTurno == idTurno);
        }
        public async Task<List<TurnoModel>> BuscarTodosTurnos()
        {
            return await _cursoDbContext.Turnos.ToListAsync();
        }
        public async Task<TurnoModel> Adicionar(TurnoModel turno)
        {
            await _cursoDbContext.Turnos.AddAsync(turno);
            await _cursoDbContext.SaveChangesAsync();

            return turno;
        }
        public async Task<TurnoModel> Atualizar(TurnoModel turno, int idTurno)
        {
            TurnoModel turnoPorId = await BuscarTurnoPorId(idTurno);

            if (turnoPorId == null)
            {
                throw new Exception($"Turno não encontrado. Id: {idTurno}");
            }

            turnoPorId.IdTurno = turno.IdTurno;
            turnoPorId.Descricao = turno.Descricao;

            _cursoDbContext.Turnos.Update(turnoPorId);
            await _cursoDbContext.SaveChangesAsync();

            return turnoPorId;
        }

        public async Task<bool> Apagar(int idTurno)
        {
            TurnoModel turnoPorId = await BuscarTurnoPorId(idTurno);

            if (turnoPorId == null)
            {
                throw new Exception($"Turno não encontrado. Id: {idTurno}");
            }

            _cursoDbContext.Turnos.Remove(turnoPorId);
            await _cursoDbContext.SaveChangesAsync();
            return true;
        }
                
    }
}
