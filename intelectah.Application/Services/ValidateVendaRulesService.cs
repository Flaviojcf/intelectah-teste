using intelectah.Application.Commands.VendaCommands.CreateVenda;
using intelectah.Application.Queries.VeiculoQueries.GetVeiculoById;
using intelectah.Application.Services.Interfaces;
using MediatR;

namespace intelectah.Application.Services
{
    public class ValidateVendaRulesService : IValidateVendaRulesService
    {
        private readonly IMediator _mediator;

        public ValidateVendaRulesService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task ValidateVenda(CreateVendaCommand command)
        {
            var veiculo = await _mediator.Send(new GetVeiculoByIdQuery(command.VeiculoID));

            if (veiculo == null)
            {
                throw new Exception("Veículo não encontrado.");
            }

            if (command.PrecoVenda > veiculo.Preco)
            {
                throw new Exception("O preço da venda não pode ser maior que o preço do veículo.");
            }
        }
    }
}
