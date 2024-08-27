using intelectah.Application.Queries.ConcessionariaQueries.GetAllConcessionarias;
using intelectah.Application.Queries.FabricanteQueries.GetAllFabricantes;
using intelectah.Application.Queries.VeiculoQueries.GetAllVeiculos;
using intelectah.Application.Queries.VendaQueries.GetAllVendas;
using intelectah.Application.Services.Interfaces;
using intelectah.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    [Authorize]
    public class DashBoardController(IMediator mediator, IDashboardService dashboardService) : Controller
    {
        private readonly IMediator _mediator = mediator;
        private readonly IDashboardService _dashboardService = dashboardService;

        public async Task<IActionResult> Index()
        {
            var getAllVeiculosQuery = new GetAllVeiculosQuery();
            var getAllConcessionariasQuery = new GetAllConcessionariasQuery();
            var getAllFabricantesQuery = new GetAllFabricantesQuery();
            var getAllVendasQuery = new GetAllVendasQuery();

            var allVeiculos = await _mediator.Send(getAllVeiculosQuery);
            var allConcessionarias = await _mediator.Send(getAllConcessionariasQuery);
            var allFabricantes = await _mediator.Send(getAllFabricantesQuery);
            var allVendas = await _mediator.Send(getAllVendasQuery);

            var recentActivities = _dashboardService.GetRecentActivitiesAsync(allVeiculos, allConcessionarias, allFabricantes, allVendas);

            var viewModel = new DashBoardViewModel
            {
                TotalVeiculos = allVeiculos.Count,
                TotalConcessionarias = allConcessionarias.Count,
                TotalFabricantes = allFabricantes.Count,
                TotalVendas = allVendas.Count,
                RecentActivities = recentActivities
            };

            return View(viewModel);
        }
    }
}
