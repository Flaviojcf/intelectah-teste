using FluentValidation;
using intelectah.MVC.Models;

namespace intelectah.MVC.Validators.Create
{
    public class LoginUsuarioValidator : AbstractValidator<LoginViewModel>
    {
        public LoginUsuarioValidator()
        {

            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("O campo Email é obrigatório.")
                .Matches(@"^[^@\s]+@[^@\s]+\.[^@\s]+$").WithMessage("Email em formato inválido.");

            RuleFor(x => x.Senha)
                .NotEmpty().WithMessage("O campo Senha é obrigatório.");
        }
    }
}
