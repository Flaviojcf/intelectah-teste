namespace intelectah.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string nome, string cPF, string telefone)
        {
            Nome = nome;
            CPF = cPF;
            Telefone = telefone;
        }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Telefone { get; private set; }
    }
}
