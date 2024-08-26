using intelectah.Application.Commands.FabricanteCommands.CreateFabricante;
using intelectah.Application.Queries.FabricanteQueries.GetFabricanteByName;
using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Exceptions;
using MediatR;

namespace intelectah.Application.Services
{
    public class ValidateFabricanteRulesService(IMediator mediator) : IValidateFabricanteRulesService
    {
        private readonly IMediator _mediator = mediator;

        public async Task ValidateFabricante(CreateFabricanteCommand command)
        {
            await this.ValidateFabricanteNome(command.Nome);

            this.AddTrimFields(command);
        }

        private async Task ValidateFabricanteNome(string nome)
        {
            var query = new GetFabricanteByNameQuery(nome);

            var fabricante = await _mediator.Send(query);

            if (fabricante != null)
            {
                throw new FabricanteAlreadyExistException(fabricante.Nome);
            }

        }

        private void AddTrimFields(CreateFabricanteCommand command)
        {
            command.Nome = command.Nome?.Trim();
            command.PaisOrigem = command.PaisOrigem?.Trim();
            command.Website = command.Website?.Trim();
        }


    }
}
