using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using Microsoft.EntityFrameworkCore;

namespace intelectah.Infrastructure.Persistance.Repositories
{
    public class UsuarioRepository(IntelectahDbContext dbContext) : IUsuarioRepository
    {

        private readonly IntelectahDbContext _dbContext = dbContext;

        public async Task CreateAsync(Usuario usuario)
        {
            await _dbContext.Usuario.AddAsync(usuario);

            await _dbContext.SaveChangesAsync();
        }

        public Task<List<Usuario>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<Usuario> GetUsuarioByEmailAndPasswordAsync(string email, string passwordHash)
        {
            return await _dbContext.Usuario.SingleOrDefaultAsync(u => u.Email == email && u.Senha == passwordHash);
        }

        public async Task<Usuario> GetUsuarioByEmailAsync(string email)
        {
            return await _dbContext.Usuario.SingleOrDefaultAsync(u => u.Email == email);
        }

        public Task SaveChangesAsync()
        {
            throw new NotImplementedException();
        }
    }
}
