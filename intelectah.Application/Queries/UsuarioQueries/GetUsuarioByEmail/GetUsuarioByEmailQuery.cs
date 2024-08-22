using intelectah.Domain.Entities;
using MediatR;

namespace intelectah.Application.Queries.UsuarioQueries.GetUsuarioByEmail
{
    public class GetUsuarioByEmailQuery(string email) : IRequest<Usuario>
    {
        public string Email { get; set; } = email;
    }
}
