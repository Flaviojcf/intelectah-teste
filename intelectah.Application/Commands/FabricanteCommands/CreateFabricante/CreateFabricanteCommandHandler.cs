using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.FabricanteCommands.CreateFabricante
{
    public class CreateFabricanteCommandHandler(IFabricanteRepository fabricanteRepository, IValidateFabricanteRulesService validateFabricanteRulesService) : IRequestHandler<CreateFabricanteCommand, int>
    {
        private readonly IFabricanteRepository _fabricanteRepository = fabricanteRepository;
        private readonly IValidateFabricanteRulesService _validateFabricanteRulesService = validateFabricanteRulesService;
        public async Task<int> Handle(CreateFabricanteCommand request, CancellationToken cancellationToken)
        {
            await _validateFabricanteRulesService.ValidateFabricante(request);

            var fabricante = new Fabricante(request.Nome, request.PaisOrigem, request.AnoFundacao, request.Website);

            await _fabricanteRepository.CreateAsync(fabricante);

            return fabricante.Id;
        }
    }
}
