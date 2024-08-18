using intelectah.Domain.Entities;
using intelectah.Domain.TypesEnum;
using intelectah.Domain.Validation;

namespace intelectah.Tests.Domain
{
    [Collection(nameof(Veiculo))]
    public class VeiculoUnitTest
    {
        [Fact]
        [Trait("Domain", "Create Veiculo")]
        public void CreateVeiculo_WithValidData_ReturnsVeiculo()
        {
            var veiculo = new Veiculo("Veiculo Model", 2020, 50300, TipoVeiculo.Carro, "Um carro", 1);

            Assert.Equal("Veiculo Model", veiculo.Modelo);
            Assert.Equal(2020, veiculo.AnoFabricacao);
            Assert.Equal(50300, veiculo.Preco);
            Assert.Equal(TipoVeiculo.Carro, veiculo.TipoVeiculo);
            Assert.Equal("Um carro", veiculo.Descricao);
            Assert.Equal(1, veiculo.FabricanteID);
            Assert.True(veiculo.IsActive);
        }

        [Fact]
        [Trait("Domain", "Create Veiculo")]
        public void CreateVeiculo_WithInvalidModelo_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Veiculo("", 2020, 50300, TipoVeiculo.Carro, "Um carro", 1));

            Assert.Equal("O modelo é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Veiculo")]
        public void CreateVeiculo_WithInvalidAnoFabricacao_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Veiculo("Veiculo Model", 0, 50300, TipoVeiculo.Carro, "Um carro", 1));

            Assert.Equal("O ano de fabricação deve ser maior que zero", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Veiculo")]
        public void CreateVeiculo_WithInvalidPreco_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Veiculo("Veiculo Model", 2020, 0, TipoVeiculo.Carro, "Um carro", 1));

            Assert.Equal("O preço deve ser maior que zero", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Veiculo")]
        public void CreateVeiculo_WithInvalidTipoVeiculo_ThrowsDomainExceptionValidation()
        {
            var invalidTipoVeiculo = (TipoVeiculo)999;

            var exception = Assert.Throws<DomainExceptionValidation>(() => new Veiculo("Veiculo Model", 2020, 50300, invalidTipoVeiculo, "Um carro", 1));

            Assert.Equal("O tipo de veículo é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Veiculo")]
        public void CreateVeiculo_WithInvalidDescricao_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Veiculo("Veiculo Model", 2020, 50300, TipoVeiculo.Carro, "", 1));

            Assert.Equal("A descrição é obrigatória", exception.Message);

        }

        [Fact]
        [Trait("Domain", "Create Veiculo")]
        public void CreateVeiculo_WithInvalidFabricanteID_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Veiculo("Veiculo Model", 2020, 50300, TipoVeiculo.Carro, "Um carro", 0));

            Assert.Equal("O ID do fabricante deve ser válido", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Veiculo")]
        public void UpdateVeiculo_WithValidData_UpdatesProperties()
        {
            var veiculo = new Veiculo("Veiculo Model", 2020, 50300, TipoVeiculo.Carro, "Um carro", 1);
            veiculo.Update("Novo Modelo", 2021, 60000, TipoVeiculo.Moto, "Uma moto", 2);

            Assert.Equal("Novo Modelo", veiculo.Modelo);
            Assert.Equal(2021, veiculo.AnoFabricacao);
            Assert.Equal(60000, veiculo.Preco);
            Assert.Equal(TipoVeiculo.Moto, veiculo.TipoVeiculo);
            Assert.Equal("Uma moto", veiculo.Descricao);
            Assert.Equal(2, veiculo.FabricanteID);
        }

        [Fact]
        [Trait("Domain", "Update Veiculo")]
        public void UpdateVeiculo_WithInvalidModelo_ThrowsDomainExceptionValidation()
        {
            var veiculo = new Veiculo("Veiculo Model", 2020, 50300, TipoVeiculo.Carro, "Um carro", 1);

            var exception = Assert.Throws<DomainExceptionValidation>(() => veiculo.Update("", 2021, 60000, TipoVeiculo.Moto, "Uma moto", 2));

            Assert.Equal("O modelo é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Veiculo")]
        public void UpdateVeiculo_WithInvalidAnoFabricacao_ThrowsDomainExceptionValidation()
        {
            var veiculo = new Veiculo("Veiculo Model", 2020, 50300, TipoVeiculo.Carro, "Um carro", 1);

            var exception = Assert.Throws<DomainExceptionValidation>(() => veiculo.Update("Novo Modelo", 0, 60000, TipoVeiculo.Moto, "Uma moto", 2));

            Assert.Equal("O ano de fabricação deve ser maior que zero", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Veiculo")]
        public void UpdateVeiculo_WithInvalidPreco_ThrowsDomainExceptionValidation()
        {
            var veiculo = new Veiculo("Veiculo Model", 2020, 50300, TipoVeiculo.Carro, "Um carro", 1);

            var exception = Assert.Throws<DomainExceptionValidation>(() => veiculo.Update("Novo Modelo", 2021, 0, TipoVeiculo.Moto, "Uma moto", 2));

            Assert.Equal("O preço deve ser maior que zero", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Veiculo")]
        public void UpdateVeiculo_WithInvalidTipoVeiculo_ThrowsDomainExceptionValidation()
        {
            var invalidTipoVeiculo = (TipoVeiculo)999;

            var veiculo = new Veiculo("Veiculo Model", 2020, 50300, TipoVeiculo.Carro, "Um carro", 1);

            var exception = Assert.Throws<DomainExceptionValidation>(() => veiculo.Update("Novo Modelo", 2021, 60000, invalidTipoVeiculo, "Uma moto", 2));

            Assert.Equal("O tipo de veículo é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Veiculo")]
        public void UpdateVeiculo_WithInvalidDescricao_ThrowsDomainExceptionValidation()
        {
            var veiculo = new Veiculo("Veiculo Model", 2020, 50300, TipoVeiculo.Carro, "Um carro", 1);

            var exception = Assert.Throws<DomainExceptionValidation>(() => veiculo.Update("Novo Modelo", 2021, 60000, TipoVeiculo.Moto, "", 2));

            Assert.Equal("A descrição é obrigatória", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Veiculo")]
        public void UpdateVeiculo_WithInvalidFabricanteID_ThrowsDomainExceptionValidation()
        {
            var veiculo = new Veiculo("Veiculo Model", 2020, 50300, TipoVeiculo.Carro, "Um carro", 1);

            var exception = Assert.Throws<DomainExceptionValidation>(() => veiculo.Update("Novo Modelo", 2021, 60000, TipoVeiculo.Moto, "Uma moto", 0));

            Assert.Equal("O ID do fabricante deve ser válido", exception.Message);
        }

        [Fact]
        [Trait("Domain", "DeActive Veiculo")]
        public void DeActive_WhenCalled_SetsIsActiveToFalseAndUpdateDate()
        {
            var veiculo = new Veiculo("Veiculo Model", 2020, 50300, TipoVeiculo.Carro, "Um carro", 1);

            veiculo.DeActive();

            Assert.False(veiculo.IsActive);
            Assert.True(veiculo.UpdatedAt > DateTime.Now.AddSeconds(-1));
        }
    }
}
