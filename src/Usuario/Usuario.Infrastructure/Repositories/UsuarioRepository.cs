using Microsoft.EntityFrameworkCore;
using Usuario.Infrastructure.Data;
using Usuario.Domain.Models;
using Usuario.Infrastructure.Repositories.Interfaces;


namespace Usuario.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly UsuarioDbContext _dbContext;

        public UsuarioRepository(UsuarioDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<UsuarioModel>> GetAll()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<UsuarioModel> GetById(int idusuario)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(a => a.IdUsuario == idusuario);
        }

        public async Task<UsuarioModel> Create(UsuarioModel usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;   
        }

        public async Task<UsuarioModel> Update(UsuarioModel usuario, int idusuario)
        {
            UsuarioModel usuarioExistente = await GetById(idusuario);
            if (usuarioExistente == null)
            {
                throw new Exception($"Usuário para o ID: {idusuario} não foi encontrado no banco de dados.");   
            }

            usuarioExistente.Nome = usuario.Nome;
            usuarioExistente.Login = usuario.Login;
            usuarioExistente.Senha = usuario.Senha;
            usuarioExistente.Celular = usuario.Celular;
            usuarioExistente.Email = usuario.Email;
            usuarioExistente.DataNascimento = usuario.DataNascimento.Date; ;
            usuarioExistente.Administrador = usuario.Administrador;

            _dbContext.Usuarios.Update(usuarioExistente);
            await _dbContext.SaveChangesAsync();

            return usuarioExistente;
        }

        public async Task<bool> DeleteById(int idusuario)
        {
            UsuarioModel usuarioExistente = await GetById(idusuario);
            if (usuarioExistente == null)
            {
                throw new Exception($"Usuario para o ID: {idusuario} não foi encontrado no banco de dados.");
            }
            
            _dbContext.Usuarios.Remove(usuarioExistente);
            await _dbContext.SaveChangesAsync();

            return true;
        }
    }
}
