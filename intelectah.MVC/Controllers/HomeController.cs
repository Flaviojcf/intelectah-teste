using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IMediator _mediator;

        public HomeController(ILogger<HomeController> logger, IMediator mediator)
        {
            _logger = logger;
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View("Login");
        }

        public IActionResult Login()
        {
            return View("Login");
        }
    }
}
