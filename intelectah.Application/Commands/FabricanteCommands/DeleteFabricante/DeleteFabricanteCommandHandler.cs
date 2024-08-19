using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.FabricanteCommands.DeleteFabricante
{
    public class DeleteFabricanteCommandHandler(IFabricanteRepository fabricanteRepository) : IRequestHandler<DeleteFabricanteCommand, Unit>
    {
        private readonly IFabricanteRepository _fabricanteRepository = fabricanteRepository;
        public async Task<Unit> Handle(DeleteFabricanteCommand request, CancellationToken cancellationToken)
        {
            var fabricante = await _fabricanteRepository.GetByIdAsync(request.Id);

            fabricante.DeActive();

            await _fabricanteRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
