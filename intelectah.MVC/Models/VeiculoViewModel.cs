using intelectah.Domain.Entities;
using intelectah.Domain.TypesEnum;

namespace intelectah.MVC.Models
{
    public class VeiculoViewModel
    {
        public string? Modelo { get; set; }
        public int AnoFabricacao { get; set; }
        public decimal Preco { get; set; }
        public TipoVeiculo TipoVeiculo { get; set; }
        public int FabricanteId { get; set; }
        public string? Descricao { get; set; }
        public IList<Veiculo> Veiculos { get; set; }
        public IList<Fabricante> Fabricantes { get; set; }
    }
}
