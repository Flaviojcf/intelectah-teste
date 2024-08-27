using intelectah.Domain.Entities;

namespace intelectah.MVC.Models
{
    public class FabricantesViewModel
    {
        public string? Nome { get; set; }
        public string? PaisOrigem { get; set; }
        public int AnoFundacao { get; set; }
        public string? Website { get; set; }
        public IList<Fabricante> Fabricantes { get; set; }
    }
}
