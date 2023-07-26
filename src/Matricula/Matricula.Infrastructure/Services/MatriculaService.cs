using Matricula.Domain.Models;
using Matricula.Infrastructure.Repositories.Interfaces;
using Matricula.Infrastructure.Services.Interfaces;

namespace Matricula.Infrastructure.Services
{
    public class MatriculaService : IMatriculaService
    {

        private readonly IMatriculaRepository _matriculaRepository;

        public MatriculaService(IMatriculaRepository matriculaRepository)
        {
            _matriculaRepository = matriculaRepository;
        }

        public async Task<List<MatriculaModel>> GetAll()
        {
            return await _matriculaRepository.GetAll();
        }

        public async Task<MatriculaModel> GetById(int idmatricula)
        {
            return await _matriculaRepository.GetById(idmatricula);
        }

        public async Task<MatriculaModel> Create(MatriculaModel matricula)
        {
            return await _matriculaRepository.Create(matricula);
        }

        public async Task<MatriculaModel> Update(MatriculaModel matricula, int idmatricula)
        {
            return await _matriculaRepository.Update(matricula, idmatricula);
        }

        public async Task<bool> DeleteById(int idmatricula)
        {
            return await _matriculaRepository.DeleteById(idmatricula);
        }
    }
}
