using FluentValidation;
using intelectah.MVC.Models;

namespace intelectah.MVC.Validators.Create
{
    public class CreateVendaValidator : AbstractValidator<VendaViewModel>
    {
        public CreateVendaValidator()
        {

            RuleFor(v => v.DataVenda.Date)
                .LessThanOrEqualTo(DateTime.Now.Date)
                .WithMessage("A data da venda não pode ser no futuro.");


            RuleFor(v => v.PrecoVenda)
                .GreaterThan(0).WithMessage("O preço de venda deve ser maior que zero.");

            RuleFor(v => v.ClienteID)
                .NotEmpty()
                .WithMessage("O cliente deve ser selecionado.");

            RuleFor(v => v.ConcessionariaID)
                .NotEmpty()
                .WithMessage("A concessionária deve ser selecionada.");

            RuleFor(v => v.FabricanteID)
                .NotEmpty()
                .WithMessage("O fabricante deve ser selecionado.");

            RuleFor(v => v.VeiculoID)
                .NotEmpty().WithMessage("O veículo deve ser selecionado.");
        }

    }
}