using intelectah.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace intelectah.MVC.Models
{
    public class VendaViewModel
    {
        [Required(ErrorMessage = "A data da venda é obrigatória")]
        public DateTime DataVenda { get; set; }

        [Required(ErrorMessage = "O preço da venda é obrigatório")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço da venda deve ser maior que zero")]
        public decimal PrecoVenda { get; set; }

        [Required(ErrorMessage = "O protocolo de venda é obrigatório")]
        [StringLength(20, ErrorMessage = "O protocolo de venda deve ter no máximo 20 caracteres")]
        public string ProtocoloVenda { get; set; }

        [Required(ErrorMessage = "O ID do veículo é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID do veículo deve ser válido")]
        public int VeiculoID { get; set; }

        [Required(ErrorMessage = "O ID da concessionária é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID da concessionária deve ser válido")]
        public int ConcessionariaID { get; set; }

        [Required(ErrorMessage = "O ID do cliente é obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "O ID do cliente deve ser válido")]
        public int ClienteID { get; set; }


        public IList<Venda> Vendas { get; set; }
        public IList<Concessionaria> Concessionarias { get; set; }
        public IList<Veiculo> Veiculos { get; set; }
        public IList<Cliente> Clientes { get; set; }
        public IList<Fabricante> Fabricantes { get; set; }
    }
}
