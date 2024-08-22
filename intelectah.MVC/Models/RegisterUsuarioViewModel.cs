using intelectah.Domain.TypesEnum;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace intelectah.MVC.Models
{
    public class RegisterUsuarioViewModel
    {
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "O campo Email é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email em formato inválido.")]
        public string? Email { get; set; }

        [Required(ErrorMessage = "O campo Senha é obrigatório.")]
        [DataType(DataType.Password)]
        public string? Senha { get; set; }

        [Required(ErrorMessage = "O campo Nível de Acesso é obrigatório.")]
        public NivelAcesso NivelAcesso { get; set; }

        public IEnumerable<SelectListItem>? NivelAcessos { get; set; }
    }
}
