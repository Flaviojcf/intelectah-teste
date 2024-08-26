using intelectah.Application.Commands.LoginUsuarioCommands;
using intelectah.Application.Commands.UsuarioCommands;
using intelectah.Domain.Exceptions;
using intelectah.Domain.TypesEnum;
using intelectah.MVC.Models;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;

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
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (User.Identity.IsAuthenticated)
                return Json(new { success = true, redirectUrl = Url.Action("Index", "Dashboard") });

            try
            {
                var loginUsuarioModel = await _mediator.Send(new LoginUsuarioCommand(model.Email, model.Senha));

                if (loginUsuarioModel == null)
                {
                    return Json(new { success = false, message = "Email ou senha incorretos." });
                }

                await SignInUserAsync(loginUsuarioModel.Token, loginUsuarioModel.Email, loginUsuarioModel.NivelAcesso);

                return Json(new { success = true, redirectUrl = Url.Action("Index", "Dashboard") });
            }
            catch (UsuarioAlreadyExistException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }


        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);

            return RedirectToAction("Index", "Home");
        }


        [HttpGet]
        public IActionResult Cadastrar()
        {
            if (User.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Dashboard");

            var model = new RegisterUsuarioViewModel
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
        public async Task<IActionResult> CriarConta(RegisterUsuarioViewModel model)
        {
            ModelState.Remove("NivelAcessos");

            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors)
                                               .Select(e => e.ErrorMessage)
                                               .ToList();

                return Json(new { success = false, message = errors[0] });
            }
            try
            {
                var createUsuarioCommand = new CreateUsuarioCommand(model.Nome, model.Senha, model.Email, model.NivelAcesso);

                await _mediator.Send(createUsuarioCommand);

                return Json(new { success = true, message = "Cadastro realizado com sucesso!" });
            }
            catch (UsuarioAlreadyExistException ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        private async Task SignInUserAsync(string token, string email, NivelAcesso nivelAcesso)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, token),
                new Claim(ClaimTypes.Email, email),
                new Claim(ClaimTypes.Role, nivelAcesso.ToString()) 
            };

            var authScheme = CookieAuthenticationDefaults.AuthenticationScheme;
            var principal = new ClaimsPrincipal(new ClaimsIdentity(claims, authScheme));

            await HttpContext.SignInAsync(authScheme, principal);
        }
    }
}
