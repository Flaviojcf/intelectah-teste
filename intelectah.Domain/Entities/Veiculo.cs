using intelectah.Domain.TypesEnum;
using intelectah.Domain.Validation;

namespace intelectah.Domain.Entities
{
    public class Veiculo : BaseEntity
    {
        public Veiculo(string modelo, int anoFabricacao, decimal preco, TipoVeiculo tipoVeiculo, string descricao, int fabricanteID)
        {
            ValidateDomain(modelo, anoFabricacao, preco, tipoVeiculo, descricao, fabricanteID);
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            Preco = preco;
            TipoVeiculo = tipoVeiculo;
            Descricao = descricao;
            FabricanteID = fabricanteID;
        }

        public string Modelo { get; private set; }
        public int AnoFabricacao { get; private set; }
        public decimal Preco { get; private set; }
        public TipoVeiculo TipoVeiculo { get; private set; }
        public string Descricao { get; private set; }

        public int FabricanteID { get; private set; }
        //public Fabricante Fabricante { get; private set; }

        public void Update(string modelo, int anoFabricacao, decimal preco, TipoVeiculo tipoVeiculo, string descricao, int fabricanteID)
        {
            ValidateDomain(modelo, anoFabricacao, preco, tipoVeiculo, descricao, fabricanteID);
            Modelo = modelo;
            AnoFabricacao = anoFabricacao;
            Preco = preco;
            TipoVeiculo = tipoVeiculo;
            Descricao = descricao;
            FabricanteID = fabricanteID;
        }

        private static void ValidateDomain(string modelo, int anoFabricacao, decimal preco, TipoVeiculo tipoVeiculo, string descricao, int fabricanteID)
        {
            DomainExceptionValidation.When(string.IsNullOrEmpty(modelo), "O modelo é obrigatório");
            DomainExceptionValidation.When(anoFabricacao <= 0, "O ano de fabricação deve ser maior que zero");
            DomainExceptionValidation.When(preco <= 0, "O preço deve ser maior que zero");
            DomainExceptionValidation.When(!Enum.IsDefined(typeof(TipoVeiculo), tipoVeiculo), "O tipo de veículo é obrigatório");
            DomainExceptionValidation.When(string.IsNullOrEmpty(descricao), "A descrição é obrigatória");
            DomainExceptionValidation.When(fabricanteID <= 0, "O ID do fabricante deve ser válido");
        }

    }
}
