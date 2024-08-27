using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.VeiculoCommands.UpdateVeiculo
{
    public class UpdateVeiculoCommandHandler(IVeiculoRepository veiculoRepository, IValidateVeiculoRulesService validateVeiculoRulesService) : IRequestHandler<UpdateVeiculoCommand, Unit>
    {
        private readonly IVeiculoRepository _veiculoRepository = veiculoRepository;
        private readonly IValidateVeiculoRulesService _validateVeiculoRulesService = validateVeiculoRulesService;
        public async Task<Unit> Handle(UpdateVeiculoCommand request, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepository.GetByIdAsync(request.Id);

            _validateVeiculoRulesService.ValidateUpdateVeiculo(request);

            veiculo.Update(request.Modelo, request.AnoFabricacao, request.Preco, request.TipoVeiculo, request.Descricao, request.FabricanteID);

            await _veiculoRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
