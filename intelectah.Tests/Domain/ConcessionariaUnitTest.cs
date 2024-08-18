using intelectah.Domain.Entities;
using intelectah.Domain.Validation;

namespace intelectah.Tests.Domain
{
    [Collection(nameof(Concessionaria))]
    public class ConcessionariaUnitTest
    {
        [Fact]
        [Trait("Domain", "Create Concessionaria")]
        public void CreateConcessionaria_WithValidData_ReturnsConcessionaria()
        {
            var concessionaria = new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10);

            Assert.Equal("Concessionaria Name", concessionaria.Nome);
            Assert.Equal("Concessionaria Address", concessionaria.Endereco);
            Assert.Equal("Concessionaria City", concessionaria.Cidade);
            Assert.Equal("Concessionaria State", concessionaria.Estado);
            Assert.Equal("12345678", concessionaria.CEP);
            Assert.Equal("11987654321", concessionaria.Telefone);
            Assert.Equal("concessionaria@example.com", concessionaria.Email);
            Assert.Equal(10, concessionaria.CapacidadeMaximaVeiculos);
            Assert.True(concessionaria.IsActive);
        }

        [Fact]
        [Trait("Domain", "Create Concessionaria")]
        public void CreateConcessionaria_WithEmptyName_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Concessionaria("", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10));

            Assert.Equal("O nome é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Concessionaria")]
        public void CreateConcessionaria_WithEmptyEndereco_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Concessionaria("Concessionaria Name", "", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10));

            Assert.Equal("O endereço é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Concessionaria")]
        public void CreateConcessionaria_WithEmptyCidade_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Concessionaria("Concessionaria Name", "Concessionaria Address", "", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10));

            Assert.Equal("A cidade é obrigatória", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Concessionaria")]
        public void CreateConcessionaria_WithEmptyEstado_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "", "12345678", "11987654321", "concessionaria@example.com", 10));

            Assert.Equal("O estado é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Concessionaria")]
        public void CreateConcessionaria_WithEmptyCEP_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "", "11987654321", "concessionaria@example.com", 10));

            Assert.Equal("O CEP é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Concessionaria")]
        public void CreateConcessionaria_WithEmptyTelefone_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "", "concessionaria@example.com", 10));

            Assert.Equal("O telefone é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Concessionaria")]
        public void CreateConcessionaria_WithEmptyEmail_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "", 10));

            Assert.Equal("O e-mail é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Concessionaria")]
        public void CreateConcessionaria_WithZeroCapacidadeMaxima_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 0));

            Assert.Equal("A capacidade máxima de veículos deve ser maior que zero", exception.Message);
        }


        [Fact]
        [Trait("Domain", "Update Concessionaria")]
        public void UpdateConcessionaria_WithValidData_ReturnsConcessionaria()
        {
            var concessionaria = new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10);

            concessionaria.Update("New Name", "New Address", "New City", "New State", "12345679", "11987654322", "concessionarianew@example.com", 20);

            Assert.Equal("New Name", concessionaria.Nome);
            Assert.Equal("New Address", concessionaria.Endereco);
            Assert.Equal("New City", concessionaria.Cidade);
            Assert.Equal("New State", concessionaria.Estado);
            Assert.Equal("12345679", concessionaria.CEP);
            Assert.Equal("11987654322", concessionaria.Telefone);
            Assert.Equal("concessionarianew@example.com", concessionaria.Email);
            Assert.Equal(20, concessionaria.CapacidadeMaximaVeiculos);
            Assert.True(concessionaria.IsActive);
        }

        [Fact]
        [Trait("Domain", "Update Concessionaria")]
        public void UpdateConcessionaria_WithEmptyEndereco_ThrowsDomainExceptionValidation()
        {
            var concessionaria = new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10);

            var exception = Assert.Throws<DomainExceptionValidation>(() => concessionaria.Update("Concessionaria Name", "", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10));

            Assert.Equal("O endereço é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Concessionaria")]
        public void UpdateConcessionaria_WithEmptyCidade_ThrowsDomainExceptionValidation()
        {
            var concessionaria = new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10);

            var exception = Assert.Throws<DomainExceptionValidation>(() => concessionaria.Update("Concessionaria Name", "Concessionaria Address", "", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10));

            Assert.Equal("A cidade é obrigatória", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Concessionaria")]
        public void UpdateConcessionaria_WithEmptyEstado_ThrowsDomainExceptionValidation()
        {
            var concessionaria = new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10);

            var exception = Assert.Throws<DomainExceptionValidation>(() => concessionaria.Update("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "", "12345678", "11987654321", "concessionaria@example.com", 10));

            Assert.Equal("O estado é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Concessionaria")]
        public void UpdateConcessionaria_WithEmptyCEP_ThrowsDomainExceptionValidation()
        {
            var concessionaria = new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10);

            var exception = Assert.Throws<DomainExceptionValidation>(() => concessionaria.Update("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "", "11987654321", "concessionaria@example.com", 10));

            Assert.Equal("O CEP é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Concessionaria")]
        public void UpdateConcessionaria_WithEmptyTelefone_ThrowsDomainExceptionValidation()
        {
            var concessionaria = new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10);

            var exception = Assert.Throws<DomainExceptionValidation>(() => concessionaria.Update("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "", "concessionaria@example.com", 10));

            Assert.Equal("O telefone é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Concessionaria")]
        public void UpdateConcessionaria_WithEmptyEmail_ThrowsDomainExceptionValidation()
        {
            var concessionaria = new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10);

            var exception = Assert.Throws<DomainExceptionValidation>(() => concessionaria.Update("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "", 10));

            Assert.Equal("O e-mail é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Concessionaria")]
        public void UpdateConcessionaria_WithZeroCapacidadeMaxima_ThrowsDomainExceptionValidation()
        {
            var concessionaria = new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10);

            var exception = Assert.Throws<DomainExceptionValidation>(() => concessionaria.Update("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 0));

            Assert.Equal("A capacidade máxima de veículos deve ser maior que zero", exception.Message);
        }

        [Fact]
        [Trait("Domain", "DeActive Concessionaria")]
        public void DeActive_WhenCalled_SetsIsActiveToFalseAndUpdateDate()
        {
            var concessionaria = new Concessionaria("Concessionaria Name", "Concessionaria Address", "Concessionaria City", "Concessionaria State", "12345678", "11987654321", "concessionaria@example.com", 10);

            concessionaria.DeActive();

            Assert.False(concessionaria.IsActive);
            Assert.True(concessionaria.UpdatedAt > DateTime.Now.AddSeconds(-1));
        }

    }
}
