namespace intelectah.Domain.Services
{
    public interface IVerifyUsuarioRulesService
    {
        Task ValidateUsuarioEmail(string email);
    }
}
