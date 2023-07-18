using Usuario.Domain.Models;

namespace Usuario.Infrastructure.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        Task<List<UsuarioModel>> GetAll();
        Task<UsuarioModel> GetById(int idusuario);
        Task<UsuarioModel> Create(UsuarioModel usuario);
        Task<UsuarioModel> Update(UsuarioModel usuario, int idusuario);
        Task<bool> DeleteById(int idusuario);
    }
}
