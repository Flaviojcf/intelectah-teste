using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    public class VendaController : Controller
    {
        public IActionResult Vendas()
        {
            return View();
        }
    }
}
