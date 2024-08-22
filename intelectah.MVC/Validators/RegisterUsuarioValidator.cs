using FluentValidation;
using intelectah.MVC.Models;

namespace intelectah.MVC.Validators
{
    public class RegisterUsuarioValidator : AbstractValidator<RegisterUsuarioViewModel>
    {
        public RegisterUsuarioValidator()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O campo Nome é obrigatório.");

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo Email é obrigatório.")
                .EmailAddress().WithMessage("Email em formato inválido.");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("O campo Senha é obrigatório.");

            RuleFor(x => x.NivelAcesso)
                .IsInEnum().WithMessage("O campo Nível de Acesso é inválido.");
        }
    }
}
