using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.VeiculoCommands.DeleteVeiculo
{
    public class DeleteVeiculoCommandHandler(IVeiculoRepository veiculoRepository) : IRequestHandler<DeleteVeiculoCommand, Unit>
    {
        private readonly IVeiculoRepository _veiculoRepository = veiculoRepository;
        public async Task<Unit> Handle(DeleteVeiculoCommand request, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepository.GetByIdAsync(request.Id);

            veiculo.DeActive();

            await _veiculoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
