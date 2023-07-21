using Usuario.Domain.Models;
using Usuario.Domain.Validations;
using Usuario.Infrastructure.Repositories.Interfaces;
using Usuario.Infrastructure.Services.Interfaces;

namespace Usuario.Infrastructure.Services
{
    public class UsuarioService : IUsuarioService
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _usuarioRepository.GetAll();
        }

        public async Task<UsuarioModel> GetById(int idusuario)
        {
            return await _usuarioRepository.GetById(idusuario);
        }

        public async Task<UsuarioModel> Create(UsuarioModel usuario)
        {
            if (!CPFValidator.Validate(usuario.CPF))
            {
                throw new Exception("CPF inválido!");
            }

            return await _usuarioRepository.Create(usuario);
        }

        public async Task<UsuarioModel> Update(UsuarioModel usuario, int idusuario)
        {
            if (!CPFValidator.Validate(usuario.CPF))
            {
                throw new Exception("CPF inválido!");
            }

            return await _usuarioRepository.Update(usuario, idusuario);
        }

        public async Task<bool> DeleteById(int idusuario)
        {
            return await _usuarioRepository.DeleteById(idusuario);
        }
    }
}
