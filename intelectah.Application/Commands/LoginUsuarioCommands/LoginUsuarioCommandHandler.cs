using intelectah.Application.OutPutModels;
using intelectah.Domain.Repositories;
using intelectah.Infrastructure.Auth;
using MediatR;

namespace intelectah.Application.Commands.LoginUsuarioCommands
{
    public class LoginUsuarioCommandHandler(IAuthService authService, IUsuarioRepository usuarioRepository) : IRequestHandler<LoginUsuarioCommand, LoginUsuarioOutputModel>
    {
        private readonly IUsuarioRepository _usuarioRepository = usuarioRepository;
        private readonly IAuthService _authService = authService;
        public async Task<LoginUsuarioOutputModel> Handle(LoginUsuarioCommand request, CancellationToken cancellationToken)
        {
            var passwordHash = _authService.ComputeSha256Hash(request.Password);

            var user = await _usuarioRepository.GetUsuarioByEmailAndPasswordAsync(request.Email, passwordHash);

            if (user == null)
            {
                return null;
            }

            var token = _authService.GenerateJwtToken(user.Email, user.NivelAcesso);

            var loginUsuarioOutputModel = new LoginUsuarioOutputModel(user.Email, token);

            return loginUsuarioOutputModel;
        }
    }
}
