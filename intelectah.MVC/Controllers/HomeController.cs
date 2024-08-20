using intelectah.Domain.TypesEnum;
using intelectah.MVC.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace intelectah.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
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

            return PartialView("_Register", model);
        }

    }
}
