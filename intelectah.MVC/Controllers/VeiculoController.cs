using intelectah.Application.Commands.VeiculoCommands.CreateVeiculo;
using intelectah.Application.Commands.VeiculoCommands.DeleteVeiculo;
using intelectah.Application.Commands.VeiculoCommands.UpdateVeiculo;
using intelectah.Application.Queries.FabricanteQueries.GetAllFabricantes;
using intelectah.Application.Queries.VeiculoQueries.GetAllVeiculos;
using intelectah.Application.Queries.VeiculoQueries.GetVeiculoById;
using intelectah.Domain.Exceptions;
using intelectah.Domain.Exceptions.intelectah.Domain.Exceptions;
using intelectah.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    [Authorize(Roles = "Gerente, Dev")]
    public class VeiculoController : Controller
    {
        private readonly IMediator _mediator;

        public VeiculoController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<IActionResult> Veiculos()
        {
            var getAllVeiculosQuery = new GetAllVeiculosQuery();

            var viewModel = new VeiculoViewModel
            {
                Veiculos = await _mediator.Send(getAllVeiculosQuery)
            };

            return View(viewModel);
        }


        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {
            var getAllFabricantesQuery = new GetAllFabricantesQuery();


            var viewModel = new VeiculoViewModel
            {
                Fabricantes = await _mediator.Send(getAllFabricantesQuery)
            };

            return View("CriarVeiculo", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarVeiculo(VeiculoViewModel model)
        {
            ModelState.Remove("Fabricantes");
            ModelState.Remove("Veiculos");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();

                return Json(new { success = false, message = errors[0] });
            }
            try
            {
                var createVeiculoCommand = new CreateVeiculoCommand(model.Modelo, model.AnoFabricacao, model.Preco, model.TipoVeiculo, model.Descricao, model.FabricanteId);

                await _mediator.Send(createVeiculoCommand);

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
            var viewModel = new UpdateVeiculoViewModel();

            var getAllFabricantesQuery = new GetAllFabricantesQuery();

            try
            {

                var getVeiculoByIdQuery = new GetVeiculoByIdQuery((int)id);
                var veiculo = await _mediator.Send(getVeiculoByIdQuery);

                if (veiculo != null)
                {
                    viewModel.Id = veiculo.Id;
                    viewModel.Modelo = veiculo.Modelo;
                    viewModel.AnoFabricacao = veiculo.AnoFabricacao;
                    viewModel.Preco = veiculo.Preco;
                    viewModel.TipoVeiculo = veiculo.TipoVeiculo;
                    viewModel.FabricanteId = veiculo.FabricanteID;
                    viewModel.Descricao = veiculo.Descricao;
                    viewModel.Fabricantes = await _mediator.Send(getAllFabricantesQuery);

                }

                return View("EditarVeiculo", viewModel);
            }
            catch (VeiculoNotFoundException)
            {
                return RedirectToAction("Veiculos");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }

        [HttpPut]
        public async Task<IActionResult> EditarVeiculo(UpdateVeiculoViewModel model)
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
                var updateVeiculoCommand = new UpdateVeiculoCommand(model.Id, model.Modelo, model.AnoFabricacao, model.Preco, model.TipoVeiculo, model.Descricao, model.FabricanteId);

                await _mediator.Send(updateVeiculoCommand);

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
                var deleteVeiculoCommand = new DeleteVeiculoCommand(id);

                await _mediator.Send(deleteVeiculoCommand);

                return Json(new { success = true, message = "Veiculo deletado com sucesso!" });
            }
            catch (VeiculoNotFoundException)
            {
                return Json(new { success = false, message = "O veiculo não foi encontrado." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Ocorreu um erro: {ex.Message}" });
            }
        }
    }
}
