namespace intelectah.Domain.Entities
{
    public class Venda : BaseEntity
    {
        public Venda(DateTime dataVenda, decimal precoVenda, string protocoloVenda, int veiculoID, Veiculo veiculo, int concessionariaID, Concessionaria concessionaria, int clienteID, Cliente cliente)
        {
            DataVenda = dataVenda;
            PrecoVenda = precoVenda;
            ProtocoloVenda = protocoloVenda;
            VeiculoID = veiculoID;
            Veiculo = veiculo;
            ConcessionariaID = concessionariaID;
            Concessionaria = concessionaria;
            ClienteID = clienteID;
            Cliente = cliente;
        }

        public DateTime DataVenda { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public string ProtocoloVenda { get; private set; }

        public int VeiculoID { get; private set; }
        public Veiculo Veiculo { get; private set; }

        public int ConcessionariaID { get; private set; }
        public Concessionaria Concessionaria { get; private set; }

        public int ClienteID { get; private set; }
        public Cliente Cliente { get; private set; }
    }

}
