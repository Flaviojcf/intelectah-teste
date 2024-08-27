using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.ClienteCommands.CreateCliente
{
    public class CreateClienteCommandHandler(IClienteRepository clienteRepository, IValidateClienteRulesService validateClienteRulesService) : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        private readonly IValidateClienteRulesService _validateClienteRulesService = validateClienteRulesService;
        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            await _validateClienteRulesService.ValidateCliente(request);

            var cliente = new Cliente(request.Nome, request.CPF, request.Telefone);

            await _clienteRepository.CreateAsync(cliente);

            return cliente.Id;
        }
    }
}
