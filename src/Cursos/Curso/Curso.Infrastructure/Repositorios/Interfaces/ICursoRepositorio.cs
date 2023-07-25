using Curso.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Curso.Infrastructure.Repositorios.Interfaces
{
    public interface ICursoRepositorio
    {
        Task<List<CursoModel>> BuscarTodosCursos();
        Task<CursoModel> BuscarCursoPorId(int idCurso);
        Task<CursoModel> Adicionar(CursoModel curso);
        Task<CursoModel> Atualizar(CursoModel curso, int idCurso);
        Task<bool> Apagar(int idCurso);
    }
}
