using Microsoft.EntityFrameworkCore;
using Boleto.Domain.Models;
using Boleto.Infrastructure.Data;
using Boleto.Infrastructure.Repositories.Interfaces;

namespace Boleto.Infrastructure.Repositories
{
    public class BoletoRepository : IBoletoRepository
    {
        private readonly BoletoDbContext _dbContext;

        public BoletoRepository(BoletoDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<BoletoModel>> GetAll()
        {
            return await _dbContext.Boletos.ToListAsync();
        }

        public async Task<List<BoletoModel>> GetAllByMatricula(int idMatricula)
        {
            return await _dbContext.Boletos
                                   .Where(boleto => boleto.IdMatricula == idMatricula && 
                                                    boleto.Pago == false)
                                   //.Where(boleto => boleto.Pago == false)
                                   .ToListAsync();
        }

        public async Task<BoletoModel> GetById(int idBoleto)
        {
            return await _dbContext.Boletos.FirstOrDefaultAsync(a => a.IdBoleto == idBoleto) ?? new BoletoModel { };
        }

        public async Task<BoletoModel> Create(BoletoModel boleto)
        {
            await _dbContext.Boletos.AddAsync(boleto);
            await _dbContext.SaveChangesAsync();

            return boleto;
        }

        public async Task<bool> Update(BoletoModel boleto, int idBoleto)
        {
            BoletoModel boletoExistente = await GetById(idBoleto);
            if (boletoExistente.IdBoleto == 0)
            {
                return false;
            }

            boletoExistente.Valor = boleto.Valor;
            boletoExistente.MesReferencia = boleto.MesReferencia;
            boletoExistente.DataVencimento = boleto.DataVencimento;
            boletoExistente.Pago = boleto.Pago;

            _dbContext.Boletos.Update(boletoExistente);
            await _dbContext.SaveChangesAsync();

            return true;
        }

        public async Task<bool> DeleteById(int idBoleto)
        {
            BoletoModel boletoExistente = await GetById(idBoleto);
            if (boletoExistente.IdBoleto == 0)
            {
                return false;
            }

            _dbContext.Boletos.Remove(boletoExistente);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
