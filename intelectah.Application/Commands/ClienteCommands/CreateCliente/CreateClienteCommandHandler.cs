using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.ClienteCommands.CreateCliente
{
    public class CreateClienteCommandHandler(IClienteRepository clienteRepository) : IRequestHandler<CreateClienteCommand, int>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<int> Handle(CreateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = new Cliente(request.Nome, request.CPF, request.Telefone);

            await _clienteRepository.CreateAsync(cliente);

            return cliente.Id;
        }
    }
}
