using System.ComponentModel.DataAnnotations;

namespace intelectah.MVC.Models
{
    public class UpdateConcessionariaViewModel
    {
        [Required(ErrorMessage = "O id da concessionária é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome da Concessionária é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Nome da Concessionária deve ter no máximo 100 caracteres.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O Endereço é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O Endereço deve ter no máximo 100 caracteres.")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "A Cidade é obrigatória.")]
        [MaxLength(50, ErrorMessage = "A Cidade deve ter no máximo 50 caracteres.")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O Estado é obrigatório.")]
        [MaxLength(20, ErrorMessage = "O Estado deve ter no máximo 20 caracteres.")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório.")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "O CEP deve estar no formato XXXXX-XXX.")]
        public string CEP { get; set; }

        [Required(ErrorMessage = "O Telefone é obrigatório.")]
        [RegularExpression(@"^\(\d{2}\) \d{4,5}-\d{4}$", ErrorMessage = "O Telefone deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.")]
        public string Telefone { get; set; }

        [Required(ErrorMessage = "O E-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "O E-mail deve ser válido.")]
        public string Email { get; set; }

        [Required(ErrorMessage = "A Capacidade Máxima de Veículos é obrigatória.")]
        [Range(1, int.MaxValue, ErrorMessage = "A Capacidade Máxima de Veículos deve ser um valor inteiro positivo.")]
        public int CapacidadeMaximaVeiculos { get; set; }

    }
}
