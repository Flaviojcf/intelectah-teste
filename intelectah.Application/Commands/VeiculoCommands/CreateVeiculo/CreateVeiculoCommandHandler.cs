using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.VeiculoCommands.CreateVeiculo
{
    public class CreateVeiculoCommandHandler(IVeiculoRepository veiculoRepository, IValidateVeiculoRulesService validateVeiculoRulesService) : IRequestHandler<CreateVeiculoCommand, int>
    {
        private readonly IVeiculoRepository _veiculoRepository = veiculoRepository;
        private readonly IValidateVeiculoRulesService _validateVeiculoRulesService = validateVeiculoRulesService;
        public async Task<int> Handle(CreateVeiculoCommand request, CancellationToken cancellationToken)
        {
            _validateVeiculoRulesService.ValidateVeiculo(request);

            var veiculo = new Veiculo(request.Modelo, request.AnoFabricacao, request.Preco, request.TipoVeiculo, request.Descricao, request.FabricanteID);

            await _veiculoRepository.CreateAsync(veiculo);

            return veiculo.Id;
        }
    }
}
