using intelectah.Domain.Entities;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.VeiculoQueries.GetVeiculoById
{
    public class GetVeiculoByIdQueryHandler(IVeiculoRepository veiculoRepository) : IRequestHandler<GetVeiculoByIdQuery, Veiculo>
    {
        private readonly IVeiculoRepository _veiculoRepository = veiculoRepository;
        public async Task<Veiculo> Handle(GetVeiculoByIdQuery request, CancellationToken cancellationToken)
        {
            return await _veiculoRepository.GetByIdAsync(request.Id);
        }
    }
}
