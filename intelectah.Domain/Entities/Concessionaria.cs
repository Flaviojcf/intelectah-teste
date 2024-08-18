namespace intelectah.Domain.Entities
{
    public class Concessionaria : BaseEntity
    {
        public Concessionaria(string nome, string endereco, string cidade, string estado, string cEP, string telefone, string email, int capacidadeMaximaVeiculos, ICollection<Venda> vendas)
        {
            Nome = nome;
            Endereco = endereco;
            Cidade = cidade;
            Estado = estado;
            CEP = cEP;
            Telefone = telefone;
            Email = email;
            CapacidadeMaximaVeiculos = capacidadeMaximaVeiculos;
            Vendas = vendas;
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
    }
}
