using intelectah.Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace intelectah.MVC.Models
{
    public class ClienteViewModel
    {
        [Required(ErrorMessage = "O nome do cliente é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do cliente deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O CPF é obrigatório.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "O CPF deve conter exatamente 11 dígitos numéricos.")]
        public string CPF { get; set; }

        [Required(ErrorMessage = "O telefone é obrigatório.")]
        [MaxLength(15, ErrorMessage = "O telefone deve ter no máximo 15 caracteres.")]
        [RegularExpression(@"^\+?[0-9\s\-\(\)]{7,15}$", ErrorMessage = "Insira um número de telefone válido.")]
        public string Telefone { get; set; }

        public IList<Cliente> Clientes { get; set; }
    }
}
