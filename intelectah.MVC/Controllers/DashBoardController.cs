using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace intelectah.MVC.Controllers
{
    [Authorize]
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Authorize(Roles = "Administrador")]
        public IActionResult Fabricantes()
        {
            ViewBag.Countries = GetCountries();
            return View();
        }

        private List<SelectListItem> GetCountries()
        {
            return new List<SelectListItem>
            {
                new SelectListItem { Value = "Brasil", Text = "Brasil" },
                new SelectListItem { Value = "Estados Unidos", Text = "Estados Unidos" },
                new SelectListItem { Value = "Canadá", Text = "Canadá" },
                new SelectListItem { Value = "México", Text = "México" },
                new SelectListItem { Value = "Alemanha", Text = "Alemanha" },
                new SelectListItem { Value = "França", Text = "França" },
                new SelectListItem { Value = "Reino Unido", Text = "Reino Unido" },
                new SelectListItem { Value = "Japão", Text = "Japão" },
                new SelectListItem { Value = "China", Text = "China" },
                new SelectListItem { Value = "Austrália", Text = "Austrália" }
            };
        }

    }
}
