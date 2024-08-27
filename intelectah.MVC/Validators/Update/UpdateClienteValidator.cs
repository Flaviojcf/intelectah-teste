using FluentValidation;
using intelectah.MVC.Models;

namespace intelectah.MVC.Validators.Update
{
    public class UpdateClienteValidator : AbstractValidator<UpdateClienteViewModel>
    {
        public UpdateClienteValidator()
        {
            RuleFor(c => c.Id).NotEmpty().WithMessage("O Id do Cliente não pode ser nulo.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do cliente é obrigatório.")
                .MaximumLength(100).WithMessage("O nome do cliente deve ter no máximo 100 caracteres.");

            RuleFor(c => c.CPF)
                .NotEmpty().WithMessage("O CPF é obrigatório.")
                .Matches(@"^\d{11}$").WithMessage("O CPF deve conter exatamente 11 dígitos numéricos.");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O telefone é obrigatório.")
                .Matches(@"^\d+$").WithMessage("O telefone deve conter apenas dígitos numéricos.")
                .MaximumLength(15).WithMessage("O telefone deve ter no máximo 15 caracteres.");
        }
    }
}
