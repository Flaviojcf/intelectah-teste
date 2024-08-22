using intelectah.Application.Commands.UsuarioCommands;

namespace intelectah.Application.Services
{
    public interface IValidateUsuarioRulesService
    {
        Task ValidateUsuario(CreateUsuarioCommand command);
    }
}
