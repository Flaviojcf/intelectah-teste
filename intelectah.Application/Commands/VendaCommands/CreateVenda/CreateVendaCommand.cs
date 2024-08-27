using MediatR;

namespace intelectah.Application.Commands.VendaCommands.CreateVenda
{
    public class CreateVendaCommand(DateTime dataVenda, decimal precoVenda, string protocoloVenda, int veiculoID, int concessionariaID, int clienteID) : IRequest<int>
    {
        public DateTime DataVenda { get; set; } = dataVenda;
        public decimal PrecoVenda { get; set; } = precoVenda;
        public string ProtocoloVenda { get; set; } = protocoloVenda;
        public int VeiculoID { get; set; } = veiculoID;
        public int ConcessionariaID { get; set; } = concessionariaID;
        public int ClienteID { get; set; } = clienteID;
    }
}
