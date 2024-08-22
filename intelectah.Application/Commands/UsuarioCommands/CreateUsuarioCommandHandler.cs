using intelectah.Application.Services;
using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using intelectah.Infrastructure.Auth;
using MediatR;

namespace intelectah.Application.Commands.UsuarioCommands
{
    public class CreateUsuarioCommandHandler(IUsuarioRepository usuarioRepository, IAuthService authService, IValidateUsuarioRulesService verifyUsuarioRulesService) : IRequestHandler<CreateUsuarioCommand, int>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IAuthService _authService = authService;
        private readonly IValidateUsuarioRulesService _verifyUsuarioRulesService = verifyUsuarioRulesService;
        public async Task<int> Handle(CreateUsuarioCommand request, CancellationToken cancellationToken)
        {
            await _verifyUsuarioRulesService.ValidateUsuario(request);

            var passwordHash = _authService.ComputeSha256Hash(request.Senha);

            var newUsuario = new Usuario(request.Nome, passwordHash, request.Email, request.NivelAcesso);

            await _usuarioRepository.CreateAsync(newUsuario);

            return newUsuario.Id;
        }
    }
}
