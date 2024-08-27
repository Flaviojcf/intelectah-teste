using intelectah.Domain.TypesEnum;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace intelectah.MVC.Models
{
    public class RegisterUsuarioViewModel
    {
        public string? Nome { get; set; }
        public string? Email { get; set; }
        public string? Senha { get; set; }
        public NivelAcesso NivelAcesso { get; set; }
        public IEnumerable<SelectListItem>? NivelAcessos { get; set; }
    }
}
