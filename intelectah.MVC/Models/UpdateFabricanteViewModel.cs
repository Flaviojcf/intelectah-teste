using System.ComponentModel.DataAnnotations;

namespace intelectah.MVC.Models
{
    public class UpdateFabricanteViewModel
    {
        [Required(ErrorMessage = "O id do fabricante � obrigat�rio.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do fabricante � obrigat�rio.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O pa�s de origem � obrigat�rio.")]
        public string PaisOrigem { get; set; }

        [Required(ErrorMessage = "O ano de funda��o � obrigat�rio.")]
        public int AnoFundacao { get; set; }

        [Required(ErrorMessage = "O URL do website � obrigat�rio.")]
        [Url(ErrorMessage = "Insira um URL v�lido.")]
        public string Website { get; set; }
    }


}
