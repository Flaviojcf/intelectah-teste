using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.ClienteQueries.GetClienteByCPF
{
    public class GetClienteByCPFQueryHandler(IClienteRepository clienteRepository) : IRequestHandler<GetClienteByCPFQuery, Cliente>
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;
        public async Task<Cliente> Handle(GetClienteByCPFQuery request, CancellationToken cancellationToken)
        {
            return await _clienteRepository.GetClienteByCPF(request.CPF);
        }
    }
}
