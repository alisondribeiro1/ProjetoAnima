using Curso.Domain.Models;
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
        Task<TurnoModel> Adicionar(TurnoModel turno);
        Task<TurnoModel> Atualizar(TurnoModel turno, int idTurno);
        Task<bool> Apagar(int idTurno);
    }
}
