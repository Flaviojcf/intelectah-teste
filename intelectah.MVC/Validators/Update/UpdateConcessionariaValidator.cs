using FluentValidation;
using intelectah.MVC.Models;
using System.Text.RegularExpressions;

namespace intelectah.MVC.Validators.Update
{
    public class UpdateConcessionariaValidator : AbstractValidator<UpdateConcessionariaViewModel>
    {
        public UpdateConcessionariaValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("O Id da Concessionária não pode ser nulo.");

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

            RuleFor(c => c.Telefone).Matches(@"^\d+$").WithMessage("O telefone deve conter apenas dígitos numéricos.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O E-mail não pode estar vazio.")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Email em formato inválido.");

            RuleFor(c => c.CapacidadeMaximaVeiculos)
                .GreaterThan(0).WithMessage("A Capacidade Máxima de Veículos deve ser um valor inteiro positivo.");
        }

        private bool ValidarCep(string cep)
        {
            var regex = new Regex(@"^\d{5}-\d{3}$");
            return regex.IsMatch(cep);
        }

    }
}
