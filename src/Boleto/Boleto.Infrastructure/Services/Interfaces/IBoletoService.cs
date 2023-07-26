using Boleto.Domain.Models;
using Boleto.Domain.SwaggerModels;

namespace Boleto.Infrastructure.Services.Interfaces
{
    public interface IBoletoService
    {
        Task<List<BoletoModel>> GetAll();
        Task<List<BoletoModel>> GetAllByMatricula(int idMatricula);
        Task<BoletoModel> GetById(int idBoleto);
        Task<BoletoModel> Create(BoletoSwagger boleto);
        Task<bool> Update(BoletoModel boleto, int idBoleto);
        Task<bool> DeleteById(int idBoleto);
    }
}
