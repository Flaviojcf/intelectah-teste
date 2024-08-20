using intelectah.Domain.TypesEnum;

namespace intelectah.Domain.Services
{
    public interface IAuthService
    {
        string GenerateJwtToken(string email, NivelAcesso nivelAcesso);
        string ComputeSha256Hash(string password);
    }
}
