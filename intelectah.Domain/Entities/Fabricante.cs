using intelectah.Domain.Validation;

namespace intelectah.Domain.Entities
{
    public class Fabricante : BaseEntity
    {
        public Fabricante(string nome, string paisOrigem, int anoFundacao, string website)
        {
            ValidateDomain(nome, paisOrigem, anoFundacao, website);
            Nome = nome;
            PaisOrigem = paisOrigem;
            AnoFundacao = anoFundacao;
            Website = website;
        }

        public string Nome { get; private set; }
        public string PaisOrigem { get; private set; }
        public int AnoFundacao { get; private set; }
        public string Website { get; private set; }

        //public ICollection<Veiculo> Veiculos { get; set; }

        public void Update(string nome, string paisOrigem, int anoFundacao, string website)
        {
            ValidateDomain(nome, paisOrigem, anoFundacao, website);
            Nome = nome;
            PaisOrigem = paisOrigem;
            AnoFundacao = anoFundacao;
            Website = website;
        }

        private static void ValidateDomain(string nome, string paisOrigem, int anoFundacao, string website)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(nome), "O nome é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(paisOrigem), "O pais de origem é obrigatório");
            DomainExceptionValidation.When(anoFundacao <= 0, "O ano de fundação deve ser maior que zero");
            DomainExceptionValidation.When(string.IsNullOrEmpty(website), "O website é obrigatório");
        }
    }
}
