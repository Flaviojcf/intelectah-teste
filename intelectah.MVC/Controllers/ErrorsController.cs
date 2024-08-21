using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    public class ErrorsController : Controller
    {
        [Route("Error404")]
        public IActionResult Error404()
        {
            return View();
        }
    }
}
