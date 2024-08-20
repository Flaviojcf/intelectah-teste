using intelectah.Application.Commands.UsuarioCommands;
using intelectah.Domain.TypesEnum;
using intelectah.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

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
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            var model = new RegisterViewModel
            {
                NivelAcessos = Enum.GetValues(typeof(NivelAcesso))
                    .Cast<NivelAcesso>()
                    .Select(n => new SelectListItem
                    {
                        Value = n.ToString(),
                        Text = n.ToString()
                    })
            };

            return View("Register", model);
        }


        [HttpPost]
        public async Task<IActionResult> Cadastrar(RegisterViewModel model)
        {
            var createUsuarioCommand = new CreateUsuarioCommand(model.Nome, model.Senha, model.Email, model.NivelAcesso);


            var id = await _mediator.Send(createUsuarioCommand);

            return View();
        }


    }
}
