using intelectah.Domain.Validation;

namespace intelectah.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string nome, string cpf, string telefone)
        {
            ValidateDomain(nome, cpf, telefone);
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
        }

        public string Nome { get; private set; }
        public string CPF { get; private set; }
        public string Telefone { get; private set; }

        public void Update(string nome, string cpf, string telefone)
        {
            ValidateDomain(nome, cpf, telefone);
            Nome = nome;
            CPF = cpf;
            Telefone = telefone;
        }

        private static void ValidateDomain(string nome, string cpf, string telefone)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cpf), "O cpf é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "O telefone é obrigatório");
        }
    }
}
