using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.ClienteCommands.UpdateCliente
{
    public class UpdateClienteCommandHandler(IClienteRepository clienteRepository) : IRequestHandler<UpdateClienteCommand, Unit>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        public async Task<Unit> Handle(UpdateClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);

            cliente.Update(request.Nome, request.CPF, request.Telefone);

            await _clienteRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
