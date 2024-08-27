using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.ClienteCommands.UpdateCliente
{
    public class UpdateClienteCommandHandler(IClienteRepository clienteRepository, IValidateClienteRulesService validateClienteRulesService) : IRequestHandler<UpdateClienteCommand, Unit>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        private readonly IValidateClienteRulesService _validateClienteRulesService = validateClienteRulesService;
        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);

            await _validateClienteRulesService.ValidateUpdateCliente(new UpdateClienteCommand(request.Id, request.Nome, request.CPF, request.Telefone));

            cliente.Update(request.Nome, request.CPF, request.Telefone);

            await _clienteRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
