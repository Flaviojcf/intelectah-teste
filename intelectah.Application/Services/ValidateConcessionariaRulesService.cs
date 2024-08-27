using intelectah.Application.Commands.ConcessionariaCommands.CreateConcessionaria;
using intelectah.Application.Commands.ConcessionariaCommands.UpdateConcessionaria;
using intelectah.Application.Queries.ConcessionariaQueries.GetConcessioanriaByName;
using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Exceptions;
using MediatR;

namespace intelectah.Application.Services
{
    public class ValidateConcessionariaRulesService(IMediator mediator) : IValidateConcessionariaRulesService
    {
        private readonly IMediator _mediator = mediator;

        public async Task ValidateConcessionaria(CreateConcessionariaCommand command)
        {
            await this.ValidateConcessionariaNome(command.Nome);

            AddTrimFields(command);
        }

        public async Task ValidateUpdateConcessionaria(UpdateConcessionariaCommand command)
        {
            var query = new GetConcessionariaByNameQuery(command.Nome);

            var concessionaria = await _mediator.Send(query);

            if (concessionaria != null && concessionaria.Id != command.Id)
            {
                throw new ConcessionariaAlreadyExistException(concessionaria.Nome);
            }

            UpdateTrimFields(command);
        }

        private async Task ValidateConcessionariaNome(string nome)
        {
            var query = new GetConcessionariaByNameQuery(nome);

            var concessionaria = await _mediator.Send(query);

            if (concessionaria != null)
            {
                throw new ConcessionariaAlreadyExistException(concessionaria.Nome);
            }

        }

        private static void AddTrimFields(CreateConcessionariaCommand command)
        {
            command.Nome = command.Nome?.Trim();
            command.Endereco = command.Endereco?.Trim();
            command.Cidade = command.Cidade?.Trim();
            command.Estado = command.Estado?.Trim();
            command.CEP = command.CEP?.Trim();
            command.Telefone = command.Telefone?.Trim();
            command.Email = command.Email?.Trim();
        }

        private static void UpdateTrimFields(UpdateConcessionariaCommand command)
        {
            command.Nome = command.Nome?.Trim();
            command.Endereco = command.Endereco?.Trim();
            command.Cidade = command.Cidade?.Trim();
            command.Estado = command.Estado?.Trim();
            command.CEP = command.CEP?.Trim();
            command.Telefone = command.Telefone?.Trim();
            command.Email = command.Email?.Trim();
        }


    }
}
