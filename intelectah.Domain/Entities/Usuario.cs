using intelectah.Domain.TypesEnum;

namespace intelectah.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario(string nome, string senha, string email, NivelAcesso nivelAcesso)
        {
            Nome = nome;
            Senha = senha;
            Email = email;
            NivelAcesso = nivelAcesso;
        }

        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public NivelAcesso NivelAcesso { get; private set; }
    }
}
