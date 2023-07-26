using Curso.Domain.Models;
using Curso.Domain.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Infrastructure.Repositorios.Interfaces
{
    public interface ITurnoRepositorio
    {
        Task<List<TurnoModel>> BuscarTodosTurnos();
        Task<TurnoModel> BuscarTurnoPorId(int idTurno);
        Task<TurnoModel> BuscarTurnoPorDescricao(string descricaoTurno);
        Task<TurnoModel> Adicionar(TurnoRequest turnoRequest);
        Task<TurnoModel> Atualizar(TurnoRequest turnoRequest, int idTurno);
        Task<bool> Apagar(int idTurno);
    }
}
