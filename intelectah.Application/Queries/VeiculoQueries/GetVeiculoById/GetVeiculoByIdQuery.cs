using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.VeiculoQueries.GetVeiculoById
{
    public class GetVeiculoByIdQuery(int id) : IRequest<Veiculo>
    {
        public int Id { get; set; } = id;
    }
}
