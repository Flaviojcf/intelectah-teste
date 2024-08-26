using intelectah.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace intelectah.MVC.Models
{
    public class FabricantesViewModel
    {
        [Required(ErrorMessage = "O nome do fabricante � obrigat�rio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O pa�s de origem � obrigat�rio.")]
        public string PaisOrigem { get; set; }

        [Required(ErrorMessage = "O ano de funda��o � obrigat�rio.")]
        [Range(1800, 2100, ErrorMessage = "Insira um ano v�lido.")]
        public int AnoFundacao { get; set; }

        [Required(ErrorMessage = "O URL do website � obrigat�rio.")]
        [Url(ErrorMessage = "Insira um URL v�lido.")]
        public string Website { get; set; }

        public IList<Fabricante> Fabricantes { get; set; }
    }


}
