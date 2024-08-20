using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Commands.ClienteCommands.DeleteCliente
{
    public class DeleteClienteCommandHandler(IClienteRepository clienteRepository) : IRequestHandler<DeleteClienteCommand, Unit>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        public async Task<Unit> Handle(DeleteClienteCommand request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);

            cliente.DeActive();

            await _clienteRepository.SaveChangesAsync();

            return Unit.Value;
        }
    }
}
