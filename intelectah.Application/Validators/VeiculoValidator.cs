using FluentValidation;
using intelectah.Domain.Entities;

namespace intelectah.Application.Validators
{
    public class VeiculoValidator : AbstractValidator<Veiculo>
    {
        public VeiculoValidator()
        {
            RuleFor(v => v.Modelo)
                .NotEmpty().WithMessage("O Nome do Modelo não pode estar vazio.")
                .MaximumLength(100).WithMessage("O Nome do Modelo deve ter no máximo 100 caracteres.");

            RuleFor(v => v.AnoFabricacao)
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("O Ano de Fabricação não pode ser um ano futuro.")
                .GreaterThan(1900).WithMessage("O Ano de Fabricação deve ser maior que 1900.");

            RuleFor(v => v.Preco)
                .GreaterThan(0).WithMessage("O Preço deve ser um valor numérico positivo.");

            RuleFor(v => v.FabricanteID)
                .GreaterThan(0).WithMessage("O Fabricante é obrigatório.");

            RuleFor(v => v.TipoVeiculo)
                .IsInEnum().WithMessage("O Tipo de Veículo deve ser uma das opções definidas.");

            RuleFor(v => v.Descricao)
                .MaximumLength(500).WithMessage("A Descrição deve ter no máximo 500 caracteres.")
                .When(v => !string.IsNullOrEmpty(v.Descricao));
        }
    }
}
