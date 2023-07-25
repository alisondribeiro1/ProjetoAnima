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
        public async Task<TurnoModel> BuscarTurnoPorDescricao(string descricaoTurno)
        {
            return await _cursoDbContext.Turnos.FirstOrDefaultAsync(x => x.Descricao == descricaoTurno);
        }
        public async Task<List<TurnoModel>> BuscarTodosTurnos()
        {
            return await _cursoDbContext.Turnos.ToListAsync();
        }
        public async Task<TurnoModel> Adicionar(TurnoRequest turnoRequest)
        {
            TurnoModel turnoModel = new TurnoModel
            {
                Descricao = turnoRequest.Descricao
            };

            await _cursoDbContext.Turnos.AddAsync(turnoModel);
            await _cursoDbContext.SaveChangesAsync();

            return turnoModel;
        }
        public async Task<TurnoModel> Atualizar(TurnoRequest turnoRequest, int idTurno)
        {
            TurnoModel turnoPorId = await BuscarTurnoPorId(idTurno);

            if (turnoPorId == null)
            {
                throw new Exception($"Turno não encontrado. Id: {idTurno}");
            }

            turnoPorId.Descricao = turnoRequest.Descricao;

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
