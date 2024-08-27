using intelectah.Application.Commands.FabricanteCommands.CreateFabricante;
using intelectah.Application.Commands.FabricanteCommands.DeleteFabricante;
using intelectah.Application.Commands.FabricanteCommands.UpdateFabricante;
using intelectah.Application.Queries.FabricanteQueries.GetAllFabricantes;
using intelectah.Application.Queries.FabricanteQueries.GetFabricanteById;
using intelectah.Domain.Exceptions;
using intelectah.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    [Authorize(Roles = "Administrador, Dev")]
    public class FabricanteController : Controller
    {
        private readonly IMediator _mediator;

        public FabricanteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Fabricantes()
        {
            var getAllFabricantesQuery = new GetAllFabricantesQuery();

            var viewModel = new FabricantesViewModel
            {
                Fabricantes = await _mediator.Send(getAllFabricantesQuery)
            };

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Cadastrar()
        {
            var viewModel = new FabricantesViewModel();

            return View("CriarFabricante", viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var viewModel = new UpdateFabricanteViewModel();

            try
            {

                var getFabricanteByIdQuery = new GetFabricanteByIdQuery((int)id);
                var fabricante = await _mediator.Send(getFabricanteByIdQuery);

                if (fabricante != null)
                {
                    viewModel.Id = fabricante.Id;
                    viewModel.Nome = fabricante.Nome;
                    viewModel.PaisOrigem = fabricante.PaisOrigem;
                    viewModel.AnoFundacao = fabricante.AnoFundacao;
                    viewModel.Website = fabricante.Website;

                }

                return View("EditarFabricante", viewModel);
            }
            catch (FabricanteNotFoundException)
            {
                return RedirectToAction("Fabricantes");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }

        [HttpPost]
        public async Task<IActionResult> CadastrarFabricante(FabricantesViewModel model)
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
                var createFabricanteCommand = new CreateFabricanteCommand(model.Nome, model.PaisOrigem, model.AnoFundacao, model.Website);

                await _mediator.Send(createFabricanteCommand);

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


        [HttpPut]
        public async Task<IActionResult> EditarFabricante(UpdateFabricanteViewModel model)
        {

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();

                return Json(new { success = false, message = errors[0] });
            }
            try
            {
                var updateFabricanteCommand = new UpdateFabricanteCommand(model.Id, model.Nome, model.PaisOrigem, model.AnoFundacao, model.Website);

                await _mediator.Send(updateFabricanteCommand);

                return Json(new { success = true, message = "Informações atualizadas com sucesso!" });
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

        [HttpDelete]
        public async Task<IActionResult> Deletar(int id)
        {
            try
            {
                var deleteFabricanteCommand = new DeleteFabricanteCommand(id);

                await _mediator.Send(deleteFabricanteCommand);

                return Json(new { success = true, message = "Fabricante deletado com sucesso!" });
            }
            catch (FabricanteNotFoundException)
            {
                return Json(new { success = false, message = "O fabricante não foi encontrado." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Ocorreu um erro: {ex.Message}" });
            }
        }

    }
}
