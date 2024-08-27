using intelectah.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace intelectah.MVC.Models
{
    public class FabricantesViewModel
    {
        [Required(ErrorMessage = "O nome do fabricante é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O país de origem é obrigatório.")]
        public string PaisOrigem { get; set; }

        [Required(ErrorMessage = "O ano de fundação é obrigatório.")]
        public int AnoFundacao { get; set; }

        [Required(ErrorMessage = "O URL do website é obrigatório.")]
        [Url(ErrorMessage = "Insira um URL válido.")]
        public string Website { get; set; }

        public IList<Fabricante> Fabricantes { get; set; }
    }


}
