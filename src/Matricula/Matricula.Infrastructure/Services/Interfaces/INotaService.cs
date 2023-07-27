using Nota.Domain.Models;

namespace Nota.Infrastructure.Services.Interfaces
{
    public interface INotaService
    {
        Task<List<NotaModel>> GetAll();
        Task<NotaModel> GetById(int idMatricula);
        Task<NotaModel> Create(NotaModel matricula);
        Task<NotaModel> Update(NotaModel matricula, int idMatricula);
        Task<bool> DeleteById(int idMatricula);
    }
}
