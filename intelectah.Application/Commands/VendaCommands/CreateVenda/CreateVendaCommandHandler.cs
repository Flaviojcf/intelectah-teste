using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.VendaCommands.CreateVenda
{
    public class CreateVendaCommandHandler(IVendaRepository vendaRepository) : IRequestHandler<CreateVendaCommand, int>
    {
        private readonly IVendaRepository _vendaRepository = vendaRepository;
        public async Task<int> Handle(CreateVendaCommand request, CancellationToken cancellationToken)
        {
            var venda = new Venda(request.DataVenda, request.PrecoVenda, request.ProtocoloVenda, request.VeiculoID, request.ConcessionariaID, request.ConcessionariaID);

            await _vendaRepository.CreateAsync(venda);

            return venda.Id;
        }
    }
}
