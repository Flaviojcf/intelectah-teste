using intelectah.Domain.TypesEnum;

namespace intelectah.Application.OutPutModels
{
    public class LoginUsuarioOutputModel(string email, string token, NivelAcesso nivelAcesso)
    {
        public string Email { get; private set; } = email;
        public string Token { get; private set; } = token;
        public NivelAcesso NivelAcesso { get; private set; } = nivelAcesso;
    }
}
