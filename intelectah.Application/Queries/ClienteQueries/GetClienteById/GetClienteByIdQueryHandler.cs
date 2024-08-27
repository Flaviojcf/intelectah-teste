using intelectah.Domain.Entities;
using intelectah.Domain.Exceptions;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.ClienteQueries.GetClienteById
{
    public class GetClienteByIdQueryHandler(IClienteRepository clienteRepository) : IRequestHandler<GetClienteByIdQuery, Cliente>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        public async Task<Cliente> Handle(GetClienteByIdQuery request, CancellationToken cancellationToken)
        {
            var cliente = await _clienteRepository.GetByIdAsync(request.Id);

            if (cliente == null)
            {
                throw new ClienteNotFoundException(request.Id);
            }

            return cliente;
        }
    }
}
