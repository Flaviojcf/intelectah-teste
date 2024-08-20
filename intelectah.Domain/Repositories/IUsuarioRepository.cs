using intelectah.Domain.Entities;

namespace intelectah.Domain.Repositories
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Task<Usuario> GetUsuarioByEmailAndPasswordAsync(string email, string passwordHash);
    }
}
