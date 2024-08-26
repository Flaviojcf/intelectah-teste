using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Repositories;
using MediatR;


namespace intelectah.Application.Commands.FabricanteCommands.UpdateFabricante
{
    public class UpdateFabricanteCommandHandler(IFabricanteRepository fabricanteRepository, IValidateFabricanteRulesService validateFabricanteRulesService) : IRequestHandler<UpdateFabricanteCommand, Unit>
    {
        private readonly IFabricanteRepository _fabricanteRepository = fabricanteRepository;
        private readonly IValidateFabricanteRulesService _validateFabricanteRulesService = validateFabricanteRulesService;
        public async Task<Unit> Handle(UpdateFabricanteCommand request, CancellationToken cancellationToken)
        {
            var fabricante = await _fabricanteRepository.GetByIdAsync(request.Id);

            await _validateFabricanteRulesService.ValidateUpdateFabricante(new UpdateFabricanteCommand(request.Id, request.Nome, request.PaisOrigem, request.AnoFundacao, request.Website));

            fabricante.Update(request.Nome, request.PaisOrigem, request.AnoFundacao, request.Website);

            await _fabricanteRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
