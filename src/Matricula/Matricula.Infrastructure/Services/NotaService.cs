using Nota.Domain.Models;
using Nota.Infrastructure.Repositories.Interfaces;
using Nota.Infrastructure.Services.Interfaces;

namespace Nota.Infrastructure.Services
{
    public class NotaService : INotaService
    {

        private readonly INotaRepository _notaRepository;

        public NotaService(INotaRepository notaRepository)
        {
            _notaRepository = notaRepository;
        }

        public async Task<List<NotaModel>> GetAll()
        {
            return await _notaRepository.GetAll();
        }

        public async Task<NotaModel> GetById(int idMatricula)
        {
            return await _notaRepository.GetById(idMatricula);
        }

        public async Task<NotaModel> Create(NotaModel matricula)
        {
            return await _notaRepository.Create(matricula);
        }

        public async Task<NotaModel> Update(NotaModel matricula, int idMatricula)
        {
            return await _notaRepository.Update(matricula, idMatricula);
        }

        public async Task<bool> DeleteById(int idMatricula)
        {
            return await _notaRepository.DeleteById(idMatricula);
        }
    }
}
