namespace intelectah.Application.OutPutModels
{
    public class LoginUsuarioOutputModel(string email, string token)
    {
        public string Email { get; private set; } = email;
        public string Token { get; private set; } = token;
    }
}
