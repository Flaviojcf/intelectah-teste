using intelectah.Domain.Validation;

namespace intelectah.Domain.Entities
{
    public class Concessionaria : BaseEntity
    {
        public Concessionaria(string nome, string endereco, string cidade, string estado, string cep, string telefone, string email, int capacidadeMaximaVeiculos)
        {

            ValidateDomain(nome, endereco, cidade, estado, cep, telefone, email, capacidadeMaximaVeiculos);
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
            CEP = cep;
            Telefone = telefone;
            Email = email;
            CapacidadeMaximaVeiculos = capacidadeMaximaVeiculos;
        }

        public string Nome { get; private set; }
        public string Endereco { get; private set; }
        public string Cidade { get; private set; }
        public string Estado { get; private set; }
        public string CEP { get; private set; }
        public string Telefone { get; private set; }
        public string Email { get; private set; }
        public int CapacidadeMaximaVeiculos { get; private set; }

        public ICollection<Venda> Vendas { get; private set; }




        private static void ValidateDomain(string nome, string endereco, string cidade, string estado, string cep, string telefone, string email, int capacidadeMaximaVeiculos)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(endereco), "O endereço é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cidade), "A cidade é obrigatória");
            DomainExceptionValidation.When(string.IsNullOrEmpty(estado), "O estado é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(cep), "O CEP é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(telefone), "O telefone é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(email), "O e-mail é obrigatório");
            DomainExceptionValidation.When(capacidadeMaximaVeiculos <= 0, "A capacidade máxima de veículos deve ser maior que zero");
        }
    }
}
