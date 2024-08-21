using intelectah.Application.Commands.LoginUsuarioCommands;
using intelectah.Application.Commands.UsuarioCommands;
using intelectah.Domain.Exceptions;
using intelectah.Domain.TypesEnum;
using intelectah.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace intelectah.MVC.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IMediator _mediator;

        public UsuarioController(IMediator mediator)
        {
            _mediator = mediator;
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
                NivelAcessos = Enum.GetValues(typeof(NivelAcesso)).Cast<NivelAcesso>().Select(n => new SelectListItem
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
            try
            {
                var createUsuarioCommand = new CreateUsuarioCommand(model.Nome, model.Senha, model.Email, model.NivelAcesso);

                var id = await _mediator.Send(createUsuarioCommand);

                return Json(new { success = true, message = "Cadastro realizado com sucesso!" });
            }
            catch (UsuarioAlreadyExistException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Autenticar(LoginViewModel model)
        {
            try
            {
                var loginUsuarioCommand = new LoginUsuarioCommand(model.Email, model.Senha);

                var loginUsuarioModel = await _mediator.Send(loginUsuarioCommand);

                return Json(new { success = true, message = loginUsuarioModel });
            }
            catch (UsuarioAlreadyExistException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


    }
}
