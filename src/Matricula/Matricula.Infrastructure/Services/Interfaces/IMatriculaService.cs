using Matricula.Domain.Models;

namespace Matricula.Infrastructure.Services.Interfaces
{
    public interface IMatriculaService
    {
        Task<List<MatriculaModel>> GetAll();
        Task<MatriculaModel> GetById(int idMatricula);
        Task<MatriculaModel> Create(MatriculaModel matricula);
        Task<MatriculaModel> Update(MatriculaModel matricula, int idMatricula);
        Task<bool> DeleteById(int idMatricula);
    }
}
