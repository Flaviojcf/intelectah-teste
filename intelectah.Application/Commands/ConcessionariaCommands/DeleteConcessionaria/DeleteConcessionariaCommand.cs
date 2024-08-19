using MediatR;

namespace intelectah.Application.Commands.ConcessionariaCommands.DeleteConcessionaria
{
    public class DeleteConcessionariaCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
    }
}
