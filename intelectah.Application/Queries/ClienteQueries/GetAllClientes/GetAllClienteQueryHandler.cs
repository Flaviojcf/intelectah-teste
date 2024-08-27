using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.ClienteQueries.GetAllClientes
{
    public class GetAllClienteQueryHandler(IClienteRepository clienteRepository) : IRequestHandler<GetAllClienteQuery, List<Cliente>>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        public async Task<List<Cliente>> Handle(GetAllClienteQuery request, CancellationToken cancellationToken)
        {
            return await _clienteRepository.GetAllAsync();
        }
    }
}
