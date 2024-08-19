using intelectah.Domain.Validation;

namespace intelectah.Domain.Entities
{
    public class Venda : BaseEntity
    {
        public Venda(DateTime dataVenda, decimal precoVenda, string protocoloVenda, int veiculoID, int concessionariaID, int clienteID)
        {
            ValidateDomain(dataVenda, precoVenda, protocoloVenda, veiculoID, concessionariaID, clienteID);
            DataVenda = dataVenda;
            PrecoVenda = precoVenda;
            ProtocoloVenda = protocoloVenda;
            VeiculoID = veiculoID;
            ConcessionariaID = concessionariaID;
            ClienteID = clienteID;
        }

        public DateTime DataVenda { get; private set; }
        public decimal PrecoVenda { get; private set; }
        public string ProtocoloVenda { get; private set; }

        public int VeiculoID { get; private set; }
        //public Veiculo Veiculo { get; private set; }

        public int ConcessionariaID { get; private set; }
        //public Concessionaria Concessionaria { get; private set; }

        public int ClienteID { get; private set; }
        //public Cliente Cliente { get; private set; }

        private static void ValidateDomain(DateTime dataVenda, decimal precoVenda, string protocoloVenda, int veiculoID, int concessionariaID, int clienteID)
        {
            DomainExceptionValidation.When(dataVenda == default(DateTime), "A data da venda é obrigatória");
            DomainExceptionValidation.When(precoVenda <= 0, "O preço da venda deve ser maior que zero");
            DomainExceptionValidation.When(string.IsNullOrEmpty(protocoloVenda), "O protocolo de venda é obrigatório");
            DomainExceptionValidation.When(veiculoID <= 0, "O ID do veículo deve ser válido");
            DomainExceptionValidation.When(concessionariaID <= 0, "O ID da concessionária deve ser válido");
            DomainExceptionValidation.When(clienteID <= 0, "O ID do cliente deve ser válido");
        }
    }

}
