using intelectah.Application.Commands.ClienteCommands.CreateCliente;
using intelectah.Application.Commands.ClienteCommands.DeleteCliente;
using intelectah.Application.Commands.ClienteCommands.UpdateCliente;
using intelectah.Application.Queries.ClienteQueries.GetAllClientes;
using intelectah.Application.Queries.ClienteQueries.GetClienteById;
using intelectah.Domain.Exceptions;
using intelectah.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    [Authorize(Roles = "Vendedor")]
    public class ClienteController : Controller
    {
        private readonly IMediator _mediator;

        public ClienteController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Clientes()
        {
            var getAllClientesQuery = new GetAllClientesQuery();

            var viewModel = new ClienteViewModel
            {
                Clientes = await _mediator.Send(getAllClientesQuery)
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult Cadastrar()
        {

            var viewModel = new ClienteViewModel();

            return View("CriarCliente", viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> CadastrarCliente(ClienteViewModel model)
        {
            ModelState.Remove("Clientes");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();

                return Json(new { success = false, message = errors[0] });
            }
            try
            {
                var createClienteCommand = new CreateClienteCommand(model.Nome, model.CPF, model.Telefone);

                await _mediator.Send(createClienteCommand);

                return Json(new { success = true, message = "Cadastro realizado com sucesso!" });
            }
            catch (ClienteAlreadyExistException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        public async Task<IActionResult> Editar(int id)
        {
            var viewModel = new UpdateClienteViewModel();


            try
            {

                var getClienteByIdQuery = new GetClienteByIdQuery((int)id);
                var cliente = await _mediator.Send(getClienteByIdQuery);

                if (cliente != null)
                {
                    viewModel.Id = cliente.Id;
                    viewModel.Nome = cliente.Nome;
                    viewModel.CPF = cliente.CPF;
                    viewModel.Telefone = cliente.Telefone;
                }

                return View("EditarCliente", viewModel);
            }
            catch (ClienteNotFoundException)
            {
                return RedirectToAction("Clientes");
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }

        [HttpPut]
        public async Task<IActionResult> EditarCliente(UpdateClienteViewModel model)
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
                var updateClienteCommand = new UpdateClienteCommand(model.Id, model.Nome, model.CPF, model.Telefone);

                await _mediator.Send(updateClienteCommand);

                return Json(new { success = true, message = "Informações atualizadas com sucesso!" });
            }
            catch (ClienteAlreadyExistException ex)
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
                var deleteClienteCommand = new DeleteClienteCommand(id);

                await _mediator.Send(deleteClienteCommand);

                return Json(new { success = true, message = "Cliente deletado com sucesso!" });
            }
            catch (ClienteNotFoundException)
            {
                return Json(new { success = false, message = "O cliente não foi encontrado." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = $"Ocorreu um erro: {ex.Message}" });
            }
        }
    }
}
