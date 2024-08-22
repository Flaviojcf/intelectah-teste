using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.UsuarioQueries.GetUsuarioByEmail
{
    public class GetUsuarioByEmailQueryHandler(IUsuarioRepository usuarioRepository) : IRequestHandler<GetUsuarioByEmailQuery, Usuario>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        public async Task<Usuario> Handle(GetUsuarioByEmailQuery request, CancellationToken cancellationToken)
        {
            return await _usuarioRepository.GetUsuarioByEmailAsync(request.Email);
        }
    }
}
