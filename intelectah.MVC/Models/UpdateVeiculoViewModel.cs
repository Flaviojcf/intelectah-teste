using intelectah.Domain.Entities;
using intelectah.Domain.TypesEnum;
using System.ComponentModel.DataAnnotations;

namespace intelectah.MVC.Models
{
    public class UpdateVeiculoViewModel
    {
        [Required(ErrorMessage = "O id do veiculo é obrigatório.")]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome do modelo é obrigatório.")]
        [MaxLength(100, ErrorMessage = "O nome do modelo deve ter no máximo 100 caracteres.")]
        public string Modelo { get; set; }

        [Required(ErrorMessage = "O ano de fabricação é obrigatório.")]
        [Range(1800, 2024, ErrorMessage = "Insira um ano válido.")]
        public int AnoFabricacao { get; set; }

        [Required(ErrorMessage = "O preço é obrigatório.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "O preço deve ser um valor positivo.")]
        public decimal Preco { get; set; }

        [Required(ErrorMessage = "O tipo de veículo é obrigatório.")]
        public TipoVeiculo TipoVeiculo { get; set; }

        [Required(ErrorMessage = "O fabricante é obrigatório.")]
        public int FabricanteId { get; set; }

        [MaxLength(500, ErrorMessage = "A descrição deve ter no máximo 500 caracteres.")]
        public string Descricao { get; set; }


        public IList<Fabricante> Fabricantes { get; set; }

    }
}
