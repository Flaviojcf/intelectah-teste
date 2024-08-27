using intelectah.Application.Commands.VeiculoCommands.CreateVeiculo;
using intelectah.Application.Commands.VeiculoCommands.UpdateVeiculo;

namespace intelectah.Application.Services.Interfaces
{

    public interface IValidateVeiculoRulesService
    {
        void ValidateVeiculo(CreateVeiculoCommand command);
        void ValidateUpdateVeiculo(UpdateVeiculoCommand command);
    }
}
