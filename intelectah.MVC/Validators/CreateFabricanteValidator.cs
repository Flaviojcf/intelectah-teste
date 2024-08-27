using FluentValidation;
using intelectah.MVC.Models;

namespace intelectah.MVC.Validators
{
    public class FabricanteValidator : AbstractValidator<FabricantesViewModel>
    {
        public FabricanteValidator()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("O Nome do Fabricante não pode estar vazio.")
                .MaximumLength(100).WithMessage("O Nome do Fabricante deve ter no máximo 100 caracteres.");

            RuleFor(f => f.PaisOrigem)
                .NotEmpty().WithMessage("O País de Origem não pode estar vazio.")
                .MaximumLength(50).WithMessage("O País de Origem deve ter no máximo 50 caracteres.");

            RuleFor(f => f.AnoFundacao)
                .LessThan(DateTime.Now.Year).WithMessage("O Ano de Fundação deve ser um ano válido no passado.")
                .GreaterThan(0).WithMessage("O Ano de Fundação deve ser maior que 0.");

            RuleFor(f => f.Website)
                .Must(IsValidUrl).WithMessage("O Website deve ser uma URL válida.");
        }

        private bool IsValidUrl(string url)
        {
            return Uri.TryCreate(url, UriKind.Absolute, out var uriResult)
                && (uriResult.Scheme == Uri.UriSchemeHttp || uriResult.Scheme == Uri.UriSchemeHttps);
        }
    }
}
