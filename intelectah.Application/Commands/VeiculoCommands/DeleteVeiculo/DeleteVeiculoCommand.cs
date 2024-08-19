using MediatR;

namespace intelectah.Application.Commands.VeiculoCommands.DeleteVeiculo
{
    public class DeleteVeiculoCommand(int id) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
    }
}
