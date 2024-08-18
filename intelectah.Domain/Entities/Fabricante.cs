namespace intelectah.Domain.Entities
{
    public class Fabricante : BaseEntity
    {
        public Fabricante(string nome, string paisOrigem, int anoFundacao, string website, ICollection<Veiculo> veiculos)
        {
            Nome = nome;
            PaisOrigem = paisOrigem;
            AnoFundacao = anoFundacao;
            Website = website;
            Veiculos = veiculos;
        }

        public string Nome { get; private set; }
        public string PaisOrigem { get; private set; }
        public int AnoFundacao { get; private set; }
        public string Website { get; private set; }

        public ICollection<Veiculo> Veiculos { get; set; }
    }
}
