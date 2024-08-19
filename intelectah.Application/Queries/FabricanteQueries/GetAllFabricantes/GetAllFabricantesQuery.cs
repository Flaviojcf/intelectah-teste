using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.FabricanteQueries.GetAllFabricantes
{
    public class GetAllFabricantesQuery : IRequest<List<Fabricante>>
    {
    }
}
