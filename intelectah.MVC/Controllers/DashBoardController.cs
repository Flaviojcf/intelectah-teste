using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    public class DashBoardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
