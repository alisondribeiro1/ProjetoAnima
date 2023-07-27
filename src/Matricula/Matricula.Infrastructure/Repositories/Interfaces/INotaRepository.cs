using Nota.Domain.Models;

namespace Nota.Infrastructure.Repositories.Interfaces
{
    public interface INotaRepository
    {
        Task<List<NotaModel>> GetAll();
        Task<NotaModel> GetById(int idMatricula);
        Task<NotaModel> Create(NotaModel nota);
        Task<NotaModel> Update(NotaModel nota, int idMatricula);
        Task<bool> DeleteById(int idMatricula);
    }
}
