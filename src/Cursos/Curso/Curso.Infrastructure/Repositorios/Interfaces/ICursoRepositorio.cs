using Curso.Domain.Models;
using Curso.Domain.Requests;
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
        Task<CursoModel> Adicionar(CursoRequest cursoRequest);
        Task<CursoModel> Atualizar(CursoRequest cursoRequest, int idCurso);
        Task<bool> Apagar(int idCurso);
    }
}
