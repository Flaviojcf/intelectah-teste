namespace intelectah.Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public string Nome { get; private set; }
        public string Senha { get; private set; }
        public string Email { get; private set; }
        public NivelAcesso NivelAcesso { get; private set; }
    }
}
