using intelectah.Domain.Validation;

namespace intelectah.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string nome, string CPF, string telefone)
        {
            ValidateDomain(nome, CPF, telefone);
            Nome = nome;
            this.CPF = CPF;
            Telefone = telefone;
        }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Telefone { get; private set; }

        public ICollection<Venda> Vendas { get; private set; }

        public void Update(string nome, string CPF, string telefone)
        {
            ValidateDomain(nome, CPF, telefone);
            Nome = nome;
            this.CPF = CPF;
            Telefone = telefone;
        }

        private static void ValidateDomain(string nome, string CPF, string telefone)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(CPF), "O CPF é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "O telefone é obrigatório");
        }
    }
}
