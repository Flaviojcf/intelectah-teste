using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.ConcessionariaQueries.GetConcessioanriaByName
{
    public class GetConcessionariaByNameQuery(string nome) : IRequest<Concessionaria>
    {
        public string Nome { get; set; } = nome;
    }
}
