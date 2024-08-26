using intelectah.Application.Commands.FabricanteCommands.CreateFabricante;
using intelectah.Application.Commands.FabricanteCommands.UpdateFabricante;

namespace intelectah.Application.Services.Interfaces
{
    public interface IValidateFabricanteRulesService
    {
        Task ValidateFabricante(CreateFabricanteCommand command);

        Task ValidateUpdateFabricante(UpdateFabricanteCommand command);
    }
}
