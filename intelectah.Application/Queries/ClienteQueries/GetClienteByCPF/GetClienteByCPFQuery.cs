using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.ClienteQueries.GetClienteByCPF
{
    public class GetClienteByCPFQuery(string CPF) : IRequest<Cliente>
    {
        public string CPF { get; set; } = CPF;
    }
}
