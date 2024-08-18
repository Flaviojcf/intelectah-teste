using intelectah.Domain.Entities;
using intelectah.Domain.Validation;

namespace intelectah.Tests.Domain
{
    [Collection(nameof(Fabricante))]
    public class FabricanteUnitTest
    {
        [Fact]
        [Trait("Domain", "Create Fabricante")]
        public void CreateFabricante_WithValidData_ReturnsFabricante()
        {
            var fabricante = new Fabricante("Fabricante Name", "Brasil", 2020, "https://www.fiat.com.br/");

            Assert.Equal("Fabricante Name", fabricante.Nome);
            Assert.Equal("Brasil", fabricante.PaisOrigem);
            Assert.Equal(2020, fabricante.AnoFundacao);
            Assert.Equal("https://www.fiat.com.br/", fabricante.Website);
            Assert.True(fabricante.IsActive);
        }

        [Fact]
        [Trait("Domain", "Create Fabricante")]
        public void CreateFabricante_WithInValidNome_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Fabricante("", "Brasil", 2020, "https://www.fiat.com.br/"));

            Assert.Equal("O nome é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Fabricante")]
        public void CreateFabricante_WithInValidPaisOrigem_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Fabricante("Fabricante Name", "", 2020, "https://www.fiat.com.br/"));

            Assert.Equal("O pais de origem é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Fabricante")]
        public void CreateFabricante_WithInValidAnoFundacao_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Fabricante("Fabricante Name", "Brasil", 0, "https://www.fiat.com.br/"));

            Assert.Equal("O ano de fundação deve ser maior que zero", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Fabricante")]
        public void CreateFabricante_WithInValidWebsite_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Fabricante("Fabricante Name", "Brasil", 2020, ""));

            Assert.Equal("O website é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Fabricante")]
        public void UpdateFabricante_WithValidData_UpdatesFabricante()
        {
            var fabricante = new Fabricante("Fabricante Name", "Brasil", 2020, "https://www.fiat.com.br/");
            fabricante.Update("New Fabricante Name", "Argentina", 2022, "https://www.newfiat.com.br/");

            Assert.Equal("New Fabricante Name", fabricante.Nome);
            Assert.Equal("Argentina", fabricante.PaisOrigem);
            Assert.Equal(2022, fabricante.AnoFundacao);
            Assert.Equal("https://www.newfiat.com.br/", fabricante.Website);
        }

        [Fact]
        [Trait("Domain", "Update Fabricante")]
        public void UpdateFabricante_WithInValidNome_ThrowsDomainExceptionValidation()
        {
            var fabricante = new Fabricante("Fabricante Name", "Brasil", 2020, "https://www.fiat.com.br/");

            var exception = Assert.Throws<DomainExceptionValidation>(() => fabricante.Update("", "Brasil", 2020, "https://www.fiat.com.br/"));

            Assert.Equal("O nome é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Fabricante")]
        public void UpdateFabricante_WithInValidPaisOrigem_ThrowsDomainExceptionValidation()
        {
            var fabricante = new Fabricante("Fabricante Name", "Brasil", 2020, "https://www.fiat.com.br/");

            var exception = Assert.Throws<DomainExceptionValidation>(() => fabricante.Update("Fabricante Name", "", 2020, "https://www.fiat.com.br/"));

            Assert.Equal("O pais de origem é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Fabricante")]
        public void UpdateFabricante_WithInValidAnoFundacao_ThrowsDomainExceptionValidation()
        {
            var fabricante = new Fabricante("Fabricante Name", "Brasil", 2020, "https://www.fiat.com.br/");

            var exception = Assert.Throws<DomainExceptionValidation>(() => fabricante.Update("Fabricante Name", "Brasil", 0, "https://www.fiat.com.br/"));

            Assert.Equal("O ano de fundação deve ser maior que zero", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Fabricante")]
        public void UpdateFabricante_WithInValidWebsite_ThrowsDomainExceptionValidation()
        {
            var fabricante = new Fabricante("Fabricante Name", "Brasil", 2020, "https://www.fiat.com.br/");

            var exception = Assert.Throws<DomainExceptionValidation>(() => fabricante.Update("Fabricante Name", "Brasil", 2020, ""));

            Assert.Equal("O website é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "DeActive Fabricante")]
        public void DeActive_WhenCalled_SetsIsActiveToFalseAndUpdateDate()
        {
            var fabricante = new Fabricante("Fabricante Name", "Brasil", 2020, "https://www.fiat.com.br/");

            fabricante.DeActive();

            Assert.False(fabricante.IsActive);
            Assert.True(fabricante.UpdatedAt > DateTime.Now.AddSeconds(-1));
        }
    }
}
