using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using intelectah.Domain.Services;
using MediatR;

namespace intelectah.Application.Commands.UsuarioCommands
{
    public class CreateUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IAuthService authService) : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IAuthService _authService = authService;
        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Senha);

            var usuario = new Usuario(request.Nome, passwordHash, request.Email, request.NivelAcesso);

            await _usuarioRepository.CreateAsync(usuario);

            return usuario.Id;
        }
    }
}
