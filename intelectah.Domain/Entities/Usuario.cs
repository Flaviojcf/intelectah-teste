using intelectah.Domain.TypesEnum;
using intelectah.Domain.Validation;

namespace intelectah.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string senha, string email, NivelAcesso nivelAcesso)
        {
            ValidateDomain(nome, senha, email, nivelAcesso);
            Nome = nome;
            Senha = senha;
            Email = email;
            NivelAcesso = nivelAcesso;
        }

        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public NivelAcesso NivelAcesso { get; private set; }

        public void Update(string nome, string senha, string email, NivelAcesso nivelAcesso)
        {
            ValidateDomain(nome, senha, email, nivelAcesso);
            Nome = nome;
            Senha = senha;
            Email = email;
            NivelAcesso = nivelAcesso;
        }

        private static void ValidateDomain(string nome, string senha, string email, NivelAcesso nivelAcesso)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(senha), "A senha é obrigatória");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "O e-mail é obrigatório");
            DomainExceptionValidation.When(!email.Contains("@"), "O e-mail deve ser válido");
            DomainExceptionValidation.When(!Enum.IsDefined(typeof(NivelAcesso), nivelAcesso), "O nível de acesso é obrigatório");
        }
    }
}
