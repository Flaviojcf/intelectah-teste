using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.FabricanteCommands.CreateFabricante
{
    public class CreateFabricanteCommandHandler(IFabricanteRepository fabricanteRepository) : IRequestHandler<CreateFabricanteCommand, int>
    {
        private readonly IFabricanteRepository _fabricanteRepository = fabricanteRepository;
        public async Task<int> Handle(CreateFabricanteCommand request, CancellationToken cancellationToken)
        {
            var fabricante = new Fabricante(request.Nome, request.PaisOrigem, request.AnoFundacao, request.Website);

            await _fabricanteRepository.CreateAsync(fabricante);

            return fabricante.Id;
        }
    }
}
