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
        public IActionResult Vendas()
        {
            return View();
        }
    }
}
