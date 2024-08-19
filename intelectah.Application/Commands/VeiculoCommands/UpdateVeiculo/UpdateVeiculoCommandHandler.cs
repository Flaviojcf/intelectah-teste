using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.VeiculoCommands.UpdateVeiculo
{
    public class UpdateVeiculoCommandHandler(IVeiculoRepository veiculoRepository) : IRequestHandler<UpdateVeiculoCommand, Unit>
    {
        private readonly IVeiculoRepository _veiculoRepository = veiculoRepository;
        public async Task<Unit> Handle(UpdateVeiculoCommand request, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepository.GetByIdAsync(request.Id);

            veiculo.Update(request.Modelo, request.AnoFabricacao, request.Preco, request.TipoVeiculo, request.Descricao, request.FabricanteID);

            await _veiculoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
