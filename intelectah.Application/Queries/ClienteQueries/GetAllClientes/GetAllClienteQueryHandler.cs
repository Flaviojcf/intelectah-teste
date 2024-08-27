using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.ClienteQueries.GetAllClientes
{
    public class GetAllClienteQueryHandler(IClienteRepository clienteRepository) : IRequestHandler<GetAllClientesQuery, List<Cliente>>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        public async Task<List<Cliente>> Handle(GetAllClientesQuery request, CancellationToken cancellationToken)
        {
            return await _clienteRepository.GetAllAsync();
        }
    }
}
