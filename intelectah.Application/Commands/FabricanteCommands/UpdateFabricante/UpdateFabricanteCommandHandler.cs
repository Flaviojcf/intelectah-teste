using intelectah.Domain.Repositories;
using MediatR;


namespace intelectah.Application.Commands.FabricanteCommands.UpdateFabricante
{
    public class UpdateFabricanteCommandHandler(IFabricanteRepository fabricanteRepository) : IRequestHandler<UpdateFabricanteCommand, Unit>
    {
        private readonly IFabricanteRepository _fabricanteRepository = fabricanteRepository;
        public async Task<Unit> Handle(UpdateFabricanteCommand request, CancellationToken cancellationToken)
        {
            var fabricante = await _fabricanteRepository.GetByIdAsync(request.Id);

            fabricante.Update(request.Nome, request.PaisOrigem, request.AnoFundacao, request.Website);

            await _fabricanteRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
