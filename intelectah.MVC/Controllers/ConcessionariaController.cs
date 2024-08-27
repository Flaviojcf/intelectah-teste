using intelectah.Application.Commands.ConcessionariaCommands.CreateConcessionaria;
using intelectah.Application.Commands.ConcessionariaCommands.DeleteConcessionaria;
using intelectah.Application.Commands.ConcessionariaCommands.UpdateConcessionaria;
using intelectah.Application.Queries.ConcessionariaQueries.GetAllConcessionarias;
using intelectah.Application.Queries.ConcessionariaQueries.GetConcessionariaById;
using intelectah.Domain.Exceptions;
using intelectah.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class ConcessionariaController : Controller
    {
        private readonly IMediator _mediator;

        public ConcessionariaController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Concessionarias()
        {
            var getAllConcessionariasQuery = new GetAllConcessionariasQuery();

            var viewModel = new ConcessionariaViewModel
            {
                Concessionarias = await _mediator.Send(getAllConcessionariasQuery)
            };

            return View(viewModel);
        }


        [HttpGet]
        public IActionResult Cadastrar()
        {

            var viewModel = new ConcessionariaViewModel();

            return View("CriarConcessionaria", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarConcessionaria(ConcessionariaViewModel model)
        {
            ModelState.Remove("Concessionarias");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();

                return Json(new { success = false, message = errors[0] });
            }
            try
            {
                var createConcessionariaCommand = new CreateConcessionariaCommand(model.Nome, model.Endereco, model.Cidade, model.Estado, model.CEP, model.Telefone, model.Email, model.CapacidadeMaximaVeiculos);

                await _mediator.Send(createConcessionariaCommand);

                return Json(new { success = true, message = "Cadastro realizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }


        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var viewModel = new UpdateConcessionariaViewModel();

            try
            {
                var getConcessionariaByIdQuery = new GetConcessionariaByIdQuery(id);
                var concessionaria = await _mediator.Send(getConcessionariaByIdQuery);

                if (concessionaria != null)
                {
                    viewModel.Id = concessionaria.Id;
                    viewModel.Nome = concessionaria.Nome;
                    viewModel.Endereco = concessionaria.Endereco;
                    viewModel.Cidade = concessionaria.Cidade;
                    viewModel.Estado = concessionaria.Estado;
                    viewModel.CEP = concessionaria.CEP;
                    viewModel.Telefone = concessionaria.Telefone;
                    viewModel.Email = concessionaria.Email;
                    viewModel.CapacidadeMaximaVeiculos = concessionaria.CapacidadeMaximaVeiculos;

                    return View("EditarConcessionaria", viewModel);
                }

                return RedirectToAction("Concessionarias");
            }
            catch (ConcessionariaNotFoundException)
            {
                return RedirectToAction("Concessionarias");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPut]
        public async Task<IActionResult> EditarConcessionaria(UpdateConcessionariaViewModel model)
        {
            ModelState.Remove("Concessionarias");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();

                return Json(new { success = false, message = errors[0] });
            }
            try
            {
                var updateConcessionariaCommand = new UpdateConcessionariaCommand(model.Id, model.Nome, model.Endereco, model.Cidade, model.Estado, model.CEP, model.Telefone, model.Email, model.CapacidadeMaximaVeiculos);

                await _mediator.Send(updateConcessionariaCommand);

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
                var deleteConcessionariaCommand = new DeleteConcessionariaCommand(id);

                await _mediator.Send(deleteConcessionariaCommand);

                return Json(new { success = true, message = "Concessionaria deletado com sucesso!" });
            }
            catch (ConcessionariaNotFoundException)
            {
                return Json(new { success = false, message = "A concessionaria não foi encontrado." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Ocorreu um erro: {ex.Message}" });
            }
        }
    }
}
