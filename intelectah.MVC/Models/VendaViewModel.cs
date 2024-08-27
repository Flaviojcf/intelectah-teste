using intelectah.Domain.Entities;

namespace intelectah.MVC.Models
{
    public class VendaViewModel
    {
        public DateTime DataVenda { get; set; }
        public decimal PrecoVenda { get; set; }
        public string? ProtocoloVenda { get; set; }
        public int VeiculoID { get; set; }
        public int ConcessionariaID { get; set; }
        public int ClienteID { get; set; }


        public int FabricanteID { get; set; }

        public IList<Venda> Vendas { get; set; }
        public IList<Concessionaria> Concessionarias { get; set; }
        public IList<Veiculo> Veiculos { get; set; }
        public IList<Cliente> Clientes { get; set; }
        public IList<Fabricante> Fabricantes { get; set; }
    }
}
