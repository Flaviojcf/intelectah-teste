using intelectah.Application.Commands.ConcessionariaCommands.CreateConcessionaria;
using intelectah.Application.Commands.ConcessionariaCommands.UpdateConcessionaria;

namespace intelectah.Application.Services.Interfaces
{
    public interface IValidateConcessionariaRulesService
    {
        Task ValidateConcessionaria(CreateConcessionariaCommand command);

        Task ValidateUpdateConcessionaria(UpdateConcessionariaCommand command);
    }
}
