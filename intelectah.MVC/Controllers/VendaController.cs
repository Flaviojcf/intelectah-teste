﻿using intelectah.Application.Commands.VendaCommands.CreateVenda;
using intelectah.Application.Queries.ClienteQueries.GetAllClientes;
using intelectah.Application.Queries.ConcessionariaQueries.GetAllConcessionarias;
using intelectah.Application.Queries.FabricanteQueries.GetAllFabricantes;
using intelectah.Application.Queries.VeiculoQueries.GetVeiculosByFabricante;
using intelectah.Application.Queries.VendaQueries.GetAllVendas;
using intelectah.Domain.Entities;
using intelectah.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    [Authorize(Roles = "Vendedor")]
    public class VendaController : Controller
    {
        private readonly IMediator _mediator;


        public VendaController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Vendas()
        {
            var getAllVendasQuery = new GetAllVendasQuery();

            var viewModel = new VendaViewModel
            {
                Vendas = await _mediator.Send(getAllVendasQuery)
            };

            return View(viewModel);
        }

        [HttpGet]
        public async Task<IActionResult> Cadastrar()
        {

            var getAllConcessionariaQuery = new GetAllConcessionariasQuery();
            var getAllFabricantesQuery = new GetAllFabricantesQuery();
            var getAllClienteQuery = new GetAllClientesQuery();

            var viewModel = new VendaViewModel
            {
                Clientes = await _mediator.Send(getAllClienteQuery),
                Concessionarias = await _mediator.Send(getAllConcessionariaQuery),
                Fabricantes = await _mediator.Send(getAllFabricantesQuery),
                Veiculos = new List<Veiculo>()

            };

            return View("CriarVenda", viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> CadastrarVenda(VendaViewModel model)
        {
            ModelState.Remove("Vendas");
            ModelState.Remove("Clientes");
            ModelState.Remove("Fabricantes");
            ModelState.Remove("Concessionarias");
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
                model.ProtocoloVenda = Guid.NewGuid().ToString("N").Substring(0, 18);

                var createVendaCommand = new CreateVendaCommand(model.DataVenda, model.PrecoVenda, model.ProtocoloVenda, model.VeiculoID, model.ConcessionariaID, model.ClienteID);

                await _mediator.Send(createVendaCommand);

                return Json(new { success = true, message = "Cadastro realizado com sucesso!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }

        }

        [HttpGet]
        public async Task<JsonResult> GetVeiculosByFabricante(int fabricanteId)
        {
            var getVeiculosQuery = new GetVeiculosByFabricanteQuery(fabricanteId);

            var veiculos = await _mediator.Send(getVeiculosQuery);

            return Json(veiculos.Select(v => new { v.Id, v.Modelo }));
        }

    }
}
