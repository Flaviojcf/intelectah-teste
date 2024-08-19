using MediatR;

namespace intelectah.Application.Commands.FabricanteCommands.DeleteFabricante
{
    public class DeleteFabricanteCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
    }
}
