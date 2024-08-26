using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Dashboard");

            return View("Login");
        }

        public IActionResult Login()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Dashboard");

            return View("Login");
        }

        [HttpGet]
        public IActionResult Unauthorized()
        {
            return View();
        }
    }
}
