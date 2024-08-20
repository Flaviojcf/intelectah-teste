using MediatR;

namespace intelectah.Application.Commands.ClienteCommands.DeleteCliente
{
    public class DeleteClienteCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
    }
}
