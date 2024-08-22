using intelectah.Application.Commands.UsuarioCommands;
using intelectah.Application.Queries.UsuarioQueries.GetUsuarioByEmail;
using intelectah.Domain.Exceptions;
using MediatR;

namespace intelectah.Application.Services
{
    public class ValidateUsuarioRulesService(IMediator mediator) : IValidateUsuarioRulesService
    {
        private readonly IMediator _mediator = mediator;

        public async Task ValidateUsuario(CreateUsuarioCommand command)
        {
            await this.ValidateUsuarioEmail(command.Email);

            this.AddTrimFields(command);
        }


        private async Task ValidateUsuarioEmail(string email)
        {
            var query = new GetUsuarioByEmailQuery(email);

            var usuario = await _mediator.Send(query);

            if (usuario != null)
            {
                throw new UsuarioAlreadyExistException(usuario.Email);
            }

        }

        private void AddTrimFields(CreateUsuarioCommand command)
        {
            command.Nome = command.Nome?.Trim();
            command.Email = command.Email?.Trim();
            command.Senha = command.Senha?.Trim();
        }
    }
}
