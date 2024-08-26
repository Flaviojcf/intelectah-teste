using intelectah.Application.Commands.FabricanteCommands.CreateFabricante;
using intelectah.Application.Queries.FabricanteQueries.GetAllFabricantes;
using intelectah.Domain.Exceptions;
using intelectah.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        private readonly IMediator _mediator;

        public DashBoardController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public async Task<IActionResult> Fabricantes()
        {
            var getAllFabricantesQuery = new GetAllFabricantesQuery();

            var viewModel = new FabricantesViewModel
            {
                Fabricantes = await _mediator.Send(getAllFabricantesQuery)
            };

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> Cadastrar(FabricantesViewModel model)
        {
            ModelState.Remove("Fabricantes");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();

                return Json(new { success = false, message = errors[0] });
            }
            try
            {
                var fabricanteCommand = new CreateFabricanteCommand(model.Nome, model.PaisOrigem, model.AnoFundacao, model.Website);

                await _mediator.Send(fabricanteCommand);

                return Json(new { success = true, message = "Cadastro realizado com sucesso!" });
            }
            catch (FabricanteAlreadyExistException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }

    }
}
