using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.FabricanteQueries.GetFabricanteByName
{
    public class GetFabricanteByNameQuery(string nome) : IRequest<Fabricante>
    {
        public string Nome { get; set; } = nome;
    }
}
