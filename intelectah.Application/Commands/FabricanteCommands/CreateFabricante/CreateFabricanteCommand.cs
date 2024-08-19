using MediatR;

namespace intelectah.Application.Commands.FabricanteCommands.CreateFabricante
{
    public class CreateFabricanteCommand(string nome, string paisOrigem, int anoFundacao, string website) : IRequest<int>
    {
        public string Nome { get; set; } = nome;
        public string PaisOrigem { get; set; } = paisOrigem;
        public int AnoFundacao { get;  set; } = anoFundacao;
        public string Website { get; set; } = website;
    }
}
