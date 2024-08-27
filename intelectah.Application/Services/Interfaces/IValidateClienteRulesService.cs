using intelectah.Application.Commands.ClienteCommands.CreateCliente;
using intelectah.Application.Commands.ClienteCommands.UpdateCliente;

namespace intelectah.Application.Services.Interfaces
{
    public interface IValidateClienteRulesService
    {
        Task ValidateCliente(CreateClienteCommand command);

        Task ValidateUpdateCliente(UpdateClienteCommand command);
    }
}
