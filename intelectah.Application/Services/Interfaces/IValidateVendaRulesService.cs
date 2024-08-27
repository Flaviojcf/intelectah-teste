using intelectah.Application.Commands.VendaCommands.CreateVenda;

namespace intelectah.Application.Services.Interfaces
{
    public interface IValidateVendaRulesService
    {
        Task ValidateVenda(CreateVendaCommand command);
    }
}
