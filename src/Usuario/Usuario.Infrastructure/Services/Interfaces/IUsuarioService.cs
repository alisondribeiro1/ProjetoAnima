using Usuario.Domain.Models;

namespace Usuario.Infrastructure.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<List<UsuarioModel>> GetAll();
        Task<UsuarioModel> GetById(int idusuario);
        Task<UsuarioModel> Create(UsuarioModel usuario);
        Task<UsuarioModel> Update(UsuarioModel usuario, int idusuario);
        Task<bool> DeleteById(int idusuario);
    }
}
