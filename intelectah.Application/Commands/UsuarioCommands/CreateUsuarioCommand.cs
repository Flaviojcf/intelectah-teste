using intelectah.Domain.TypesEnum;
using MediatR;

namespace intelectah.Application.Commands.UsuarioCommands
{
    public class CreateUsuarioCommand(string nome, string senha, string email, NivelAcesso nivelAcesso) : IRequest<int>
    {
        public string Nome { get; set; } = nome;
        public string Senha { get; set; } = senha;
        public string Email { get; set; } = email;
        public NivelAcesso NivelAcesso { get; set; } = nivelAcesso;
    }
}
