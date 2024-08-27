using intelectah.Application.Commands.ClienteCommands.CreateCliente;
using intelectah.Application.Commands.ClienteCommands.UpdateCliente;
using intelectah.Application.Queries.ClienteQueries.GetClienteByCPF;
using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Exceptions;
using MediatR;

namespace intelectah.Application.Services
{
    public class ValidateClienteRulesService(IMediator mediator) : IValidateClienteRulesService
    {
        private readonly IMediator _mediator = mediator;

        public async Task ValidateCliente(CreateClienteCommand command)
        {
            await this.ValidateClienteCPF(command.CPF);

            AddTrimFields(command);
        }

        public async Task ValidateUpdateCliente(UpdateClienteCommand command)
        {
            var query = new GetClienteByCPFQuery(command.CPF);

            var cliente = await _mediator.Send(query);

            if (cliente != null && cliente.Id != command.Id)
            {
                throw new ClienteAlreadyExistException(cliente.CPF);
            }

            UpdateTrimFields(command);
        }

        private async Task ValidateClienteCPF(string CPF)
        {
            var query = new GetClienteByCPFQuery(CPF);

            var cliente = await _mediator.Send(query);

            if (cliente != null)
            {
                throw new ClienteAlreadyExistException(cliente.CPF);
            }

        }

        private static void AddTrimFields(CreateClienteCommand command)
        {
            command.Telefone = command.Telefone.Trim();
            command.Nome = command.Nome.Trim();
            command.CPF = command.CPF.Trim();
        }

        private static void UpdateTrimFields(UpdateClienteCommand command)
        {
            command.Telefone = command.Telefone.Trim();
            command.Nome = command.Nome.Trim();
            command.CPF = command.CPF.Trim();
        }


    }
}
