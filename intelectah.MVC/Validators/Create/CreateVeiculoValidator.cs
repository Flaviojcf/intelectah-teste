using FluentValidation;
using intelectah.MVC.Models;

namespace intelectah.MVC.Validators.Create
{
    public class CreateVeiculoValidator : AbstractValidator<VeiculoViewModel>
    {
        public CreateVeiculoValidator()
        {
            RuleFor(v => v.Modelo)
                .NotEmpty().WithMessage("O nome do modelo é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do modelo deve ter no mávimo 100 caracteres.");

            RuleFor(v => v.AnoFabricacao)
                .NotEmpty().WithMessage("O ano de fabricação é obrigatório.")
                .LessThanOrEqualTo(DateTime.Now.Year).WithMessage("O Ano de Fundação não pode ser um ano futuro.")
                .GreaterThanOrEqualTo(1668).WithMessage("O Ano de Fabricação não pode ser anterior a 1668.");

            RuleFor(v => v.Preco)
                .NotEmpty().WithMessage("O preço é obrigatório.")
                .GreaterThan(0.01M).WithMessage("O preço deve ser um valor positivo.");

            RuleFor(v => v.TipoVeiculo)
                .IsInEnum().WithMessage("O tipo de veículo é obrigatório.");

            RuleFor(v => v.FabricanteId)
                .NotEmpty().WithMessage("O fabricante é obrigatório.");

            RuleFor(v => v.Descricao)
                .MaximumLength(500).WithMessage("A descrição deve ter no mávimo 500 caracteres.");
        }
    }
}
