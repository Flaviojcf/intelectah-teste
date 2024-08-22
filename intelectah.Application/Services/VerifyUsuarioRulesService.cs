using intelectah.Application.Queries.UsuarioQueries.GetUsuarioByEmail;
using intelectah.Domain.Exceptions;
using intelectah.Domain.Services;
using MediatR;

namespace intelectah.Application.Services
{
    public class VerifyUsuarioRulesService(IMediator mediator) : IVerifyUsuarioRulesService
    {
        private readonly IMediator _mediator = mediator;

        public async Task ValidateUsuarioEmail(string email)
        {
            var query = new GetUsuarioByEmailQuery(email);

            var usuario = await _mediator.Send(query);

            if (usuario != null)
            {
                throw new UsuarioAlreadyExistException(usuario.Email);
            }

        }

    }
}
