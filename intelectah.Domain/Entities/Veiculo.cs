using intelectah.Domain.Enum;

namespace intelectah.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public Veiculo(string modelo, int anoFabricacao, decimal preco, TipoVeiculo tipoVeiculo, string descricao, int fabricanteID, Fabricante fabricante)
        {
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            Preco = preco;
            TipoVeiculo = tipoVeiculo;
            Descricao = descricao;
            FabricanteID = fabricanteID;
            Fabricante = fabricante;
        }

        public string Modelo { get; private set; }
        public int AnoFabricacao { get; private set; }
        public decimal Preco { get; private set; }
        public TipoVeiculo TipoVeiculo { get; private set; }
        public string Descricao { get; private set; }

        public int FabricanteID { get; private set; }
        public Fabricante Fabricante { get; private set; }
    }
}
