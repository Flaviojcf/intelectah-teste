using intelectah.Domain.TypesEnum;

namespace intelectah.Infrastructure.Auth
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, NivelAcesso nivelAcesso);
        string ComputeSha256Hash(string password);
    }
}
