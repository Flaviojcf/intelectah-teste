using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.VendaCommands.CreateVenda
{
    public class CreateVendaCommandHandler(IVendaRepository vendaRepository, IValidateVendaRulesService validateVendaRulesService) : IRequestHandler<CreateVendaCommand, int>
    {
        private readonly IVendaRepository _vendaRepository = vendaRepository;
        private readonly IValidateVendaRulesService _validateVendaRulesService = validateVendaRulesService;
        public async Task<int> Handle(CreateVendaCommand request, CancellationToken cancellationToken)
        {

            await _validateVendaRulesService.ValidateVenda(request);

            var venda = new Venda(request.DataVenda, request.PrecoVenda, request.ProtocoloVenda, request.VeiculoID, request.ConcessionariaID, request.ClienteID);

            await _vendaRepository.CreateAsync(venda);

            return venda.Id;
        }
    }
}
