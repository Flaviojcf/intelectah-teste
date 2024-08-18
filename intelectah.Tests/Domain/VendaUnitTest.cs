using intelectah.Domain.Entities;
using intelectah.Domain.Validation;

namespace intelectah.Tests.Domain
{
    [Collection(nameof(Venda))]
    public class VendaUnitTest
    {
        [Fact]
        [Trait("Domain", "Create Venda")]
        public void CreateVenda_WithValidData_ReturnsVenda()
        {
            var venda = new Venda(DateTime.Now, 50000, "PROTOCOLO123", 1, 1, 1);

            Assert.True(venda.DataVenda != default);
            Assert.Equal(50000, venda.PrecoVenda);
            Assert.Equal("PROTOCOLO123", venda.ProtocoloVenda);
            Assert.Equal(1, venda.VeiculoID);
            Assert.Equal(1, venda.ConcessionariaID);
            Assert.Equal(1, venda.ClienteID);
            Assert.True(venda.IsActive);
        }

        [Fact]
        [Trait("Domain", "Create Venda")]
        public void CreateVenda_WithDefaultDate_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Venda(default, 50000, "PROTOCOLO123", 1, 1, 1));

            Assert.Equal("A data da venda é obrigatória", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Venda")]
        public void CreateVenda_WithNegativePreco_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Venda(DateTime.Now, -1, "PROTOCOLO123", 1, 1, 1));

            Assert.Equal("O preço da venda deve ser maior que zero", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Venda")]
        public void CreateVenda_WithEmptyProtocolo_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Venda(DateTime.Now, 50000, "", 1, 1, 1));

            Assert.Equal("O protocolo de venda é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Venda")]
        public void CreateVenda_WithInvalidVeiculoID_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Venda(DateTime.Now, 50000, "PROTOCOLO123", 0, 1, 1));

            Assert.Equal("O ID do veículo deve ser válido", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Venda")]
        public void CreateVenda_WithInvalidConcessionariaID_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Venda(DateTime.Now, 50000, "PROTOCOLO123", 1, 0, 1));

            Assert.Equal("O ID da concessionária deve ser válido", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Venda")]
        public void CreateVenda_WithInvalidClienteID_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Venda(DateTime.Now, 50000, "PROTOCOLO123", 1, 1, 0));

            Assert.Equal("O ID do cliente deve ser válido", exception.Message);
        }

        [Fact]
        [Trait("Domain", "DeActive Venda")]
        public void DeActive_WhenCalled_SetsIsActiveToFalseAndUpdateDate()
        {
            var venda = new Venda(DateTime.Now, 50000, "PROTOCOLO123", 1, 1, 1);

            venda.DeActive();

            Assert.False(venda.IsActive);
            Assert.True(venda.UpdatedAt > DateTime.Now.AddSeconds(-1));
        }
    }
}
