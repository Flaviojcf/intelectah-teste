﻿using intelectah.Application.OutPutModels;
using MediatR;

namespace intelectah.Application.Commands.LoginUsuario
{
    public class LoginUsuarioCommand(string email, string password) : IRequest<LoginUsuarioOutputModel>
    {
        public string Email { get; set; } = email;
        public string Password { get; set; } = password;
    }
}
