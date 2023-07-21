using Cursos.Models;

namespace Cursos.Repositorios.Interfaces
{
    public interface ICursoRepositorio
    {
        Task<List<Curso>> BuscarTodosCursos();
        Task<Curso> BuscarCursoPorId(int id);
        Task<Curso> Adicionar(Curso curso);
        Task<Curso> Atualizar(Curso curso,int id);
        Task<bool> Apagar (int id);
    }
}
