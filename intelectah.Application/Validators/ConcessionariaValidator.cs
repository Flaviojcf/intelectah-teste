using FluentValidation;
using intelectah.Domain.Entities;
using System.Text.RegularExpressions;

namespace intelectah.Application.Validators
{
    public class ConcessionariaValidator : AbstractValidator<Concessionaria>
    {
        public ConcessionariaValidator()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O Nome da Concessionária não pode estar vazio.")
                .MaximumLength(100).WithMessage("O Nome da Concessionária deve ter no máximo 100 caracteres.");

            RuleFor(c => c.Endereco)
                .NotEmpty().WithMessage("O Endereço não pode estar vazio.")
                .MaximumLength(100).WithMessage("O Endereço deve ter no máximo 100 caracteres.");

            RuleFor(c => c.Cidade)
                .NotEmpty().WithMessage("A Cidade não pode estar vazia.")
                .MaximumLength(50).WithMessage("A Cidade deve ter no máximo 50 caracteres.");

            RuleFor(c => c.Estado)
                .NotEmpty().WithMessage("O Estado não pode estar vazio.")
                .MaximumLength(20).WithMessage("O Estado deve ter no máximo 20 caracteres.");

            RuleFor(c => c.CEP)
                .NotEmpty().WithMessage("O CEP não pode estar vazio.")
                .Must(ValidarCep).WithMessage("O CEP deve estar no formato XXXXX-XXX.");

            RuleFor(c => c.Telefone)
                .Must(ValidarTelefone).WithMessage("O Telefone deve estar no formato (XX) XXXX-XXXX ou (XX) XXXXX-XXXX.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O E-mail não pode estar vazio.")
                .EmailAddress().WithMessage("O E-mail deve ter um formato válido.");

            RuleFor(c => c.CapacidadeMaximaVeiculos)
                .GreaterThan(0).WithMessage("A Capacidade Máxima de Veículos deve ser um valor inteiro positivo.");
        }

        private bool ValidarTelefone(string telefone)
        {
            var regex = new Regex(@"^\(\d{2}\) \d{4,5}-\d{4}$");
            return regex.IsMatch(telefone);
        }

        private bool ValidarCep(string cep)
        {
            var regex = new Regex(@"^\d{5}-\d{3}$");
            return regex.IsMatch(cep);
        }

    }
}
