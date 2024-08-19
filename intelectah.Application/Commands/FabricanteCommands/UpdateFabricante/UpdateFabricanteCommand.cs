
using MediatR;

namespace intelectah.Application.Commands.FabricanteCommands.UpdateFabricante
{
    public class UpdateFabricanteCommand(int id, string nome, string paisOrigem, int anoFundacao, string website) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
        public string Nome { get; set; } = nome;
        public string PaisOrigem { get; set; } = paisOrigem;
        public int AnoFundacao { get; set; } = anoFundacao;
        public string Website { get; set; } = website;
    }
}
