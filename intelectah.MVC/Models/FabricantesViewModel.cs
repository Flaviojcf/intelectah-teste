using System.ComponentModel.DataAnnotations;

namespace intelectah.MVC.Models
{
    public class FabricantesViewModel
    {
        [Required(ErrorMessage = "O nome do fabricante é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O país de origem é obrigatório.")]
        public string Pais { get; set; }

        [Required(ErrorMessage = "O ano de fundação é obrigatório.")]
        [Range(1800, 2100, ErrorMessage = "Insira um ano válido.")]
        public int AnoFundacao { get; set; }

        [Required(ErrorMessage = "O URL do website é obrigatório.")]
        [Url(ErrorMessage = "Insira um URL válido.")]
        public string Website { get; set; }
    }


}
