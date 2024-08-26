using intelectah.Application.Commands.UsuarioCommands;

namespace intelectah.Application.Services.Interfaces
{
    public interface IValidateUsuarioRulesService
    {
        Task ValidateUsuario(CreateUsuarioCommand command);
    }
}
