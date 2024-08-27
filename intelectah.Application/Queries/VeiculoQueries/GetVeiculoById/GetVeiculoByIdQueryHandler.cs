using intelectah.Domain.Entities;
using intelectah.Domain.Exceptions.intelectah.Domain.Exceptions;
using intelectah.Domain.Repositories;
using MediatR;

namespace intelectah.Application.Queries.VeiculoQueries.GetVeiculoById
{
    public class GetVeiculoByIdQueryHandler(IVeiculoRepository veiculoRepository) : IRequestHandler<GetVeiculoByIdQuery, Veiculo>
    {
        private readonly IVeiculoRepository _veiculoRepository = veiculoRepository;
        public async Task<Veiculo> Handle(GetVeiculoByIdQuery request, CancellationToken cancellationToken)
        {
            var veiculo = await _veiculoRepository.GetByIdAsync(request.Id);

            if (veiculo == null)
            {
                throw new VeiculoNotFoundException(request.Id);
            }

            return veiculo;
        }
    }
}
