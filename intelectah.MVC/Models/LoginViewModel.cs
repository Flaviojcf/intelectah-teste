using System.ComponentModel.DataAnnotations;

namespace intelectah.MVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo Email � obrigat�rio.")]
        [EmailAddress(ErrorMessage = "Email em formato inv�lido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo Senha � obrigat�rio.")]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

    }

}
