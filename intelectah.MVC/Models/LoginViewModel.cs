using System.ComponentModel.DataAnnotations;

namespace intelectah.MVC.Models
{
    public class LoginViewModel
    {
        [Required(ErrorMessage = "O campo Email � obrigat�rio.")]
        [EmailAddress(ErrorMessage = "Email em formato inv�lido.")]
        public required string Email { get; set; }

        [Required(ErrorMessage = "O campo Senha � obrigat�rio.")]
        [DataType(DataType.Password)]
        public required string Senha { get; set; }

    }

}
