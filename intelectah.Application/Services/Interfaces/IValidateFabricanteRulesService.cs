using intelectah.Application.Commands.FabricanteCommands.CreateFabricante;

namespace intelectah.Application.Services.Interfaces
{
    public interface IValidateFabricanteRulesService
    {
        Task ValidateFabricante(CreateFabricanteCommand command);
    }
}
