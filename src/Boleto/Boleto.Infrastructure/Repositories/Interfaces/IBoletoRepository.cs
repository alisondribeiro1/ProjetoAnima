using Boleto.Domain.Models;

namespace Boleto.Infrastructure.Repositories.Interfaces
{
    public interface IBoletoRepository
    {
        Task<List<BoletoModel>> GetAll();
        Task<List<BoletoModel>> GetAllByMatricula(int idMatricula);
        Task<BoletoModel> GetById(int idBoleto);
        Task<BoletoModel> Create(BoletoModel boleto);
        Task<bool> Update(BoletoModel boleto, int idBoleto);
        Task<bool> DeleteById(int idBoleto);
    }
}
