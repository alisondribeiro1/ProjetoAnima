using Aluno.Domain.Models;

namespace Aluno.Infrastructure.Repositories.Interfaces
{
    public interface IAlunoRepository
    {
        Task<List<AlunoModel>> GetAll();
        Task<AlunoModel> GetById(int id);
        Task<AlunoModel> Create(AlunoModel aluno);
        Task<AlunoModel> Update(AlunoModel aluno, int id);
        Task<bool> DeleteById(int id);
    }
}
