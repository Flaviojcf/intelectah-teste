using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace intelectah.MVC.Controllers
{
    [Authorize(Roles = "Dev")]
    public class VendaController : Controller
    {
        public IActionResult Vendas()
        {
            return View();
        }
    }
}
