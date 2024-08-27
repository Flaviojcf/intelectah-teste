using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.VeiculoQueries.GetVeiculosByFabricante
{
    public class GetVeiculosByFabricanteQuery(int fabricanteID) : IRequest<List<Veiculo>>
    {
        public int FabricanteID { get; set; } = fabricanteID;
    }
}
