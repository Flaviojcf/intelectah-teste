using intelectah.Application.Commands.VeiculoCommands.CreateVeiculo;
using intelectah.Application.Commands.VeiculoCommands.UpdateVeiculo;
using intelectah.Application.Services.Interfaces;
using MediatR;

namespace intelectah.Application.Services
{
    public class ValidateVeiculoRulesService(IMediator mediator) : IValidateVeiculoRulesService
    {
        private readonly IMediator _mediator = mediator;

        public void ValidateUpdateVeiculo(UpdateVeiculoCommand command)
        {
            UpdateTrimFields(command);
        }

        public void ValidateVeiculo(CreateVeiculoCommand command)
        {
            AddTrimFields(command);
        }


        private static void AddTrimFields(CreateVeiculoCommand command)
        {
            command.Modelo = command.Modelo?.Trim();
            command.Descricao = command.Descricao?.Trim();
        }

        private static void UpdateTrimFields(UpdateVeiculoCommand command)
        {
            command.Modelo = command.Modelo?.Trim();
            command.Descricao = command.Descricao?.Trim();
        }
    }
}
