using intelectah.Domain.Entities;
using intelectah.Domain.Validation;

namespace intelectah.Tests.Domain
{
    [Collection(nameof(Cliente))]
    public class ClienteUnitTest
    {
        [Fact]
        [Trait("Domain", "Create Cliente")]
        public void CreateCliente_WithValidData_ReturnsCliente()
        {
            var cliente = new Cliente("Client Name", "12345678901", "11987654321");

            Assert.Equal("Client Name", cliente.Nome);
            Assert.Equal("12345678901", cliente.CPF);
            Assert.Equal("11987654321", cliente.Telefone);
            Assert.True(cliente.IsActive);
        }

        [Fact]
        [Trait("Domain", "Create Cliente")]
        public void CreateCliente_WithInvalidName_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Cliente("", "12345678901", "11987654321"));

            Assert.Equal("O nome é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Cliente")]
        public void CreateCliente_WithInvalidCPF_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Cliente("Client Name", "", "11987654321"));

            Assert.Equal("O cpf é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Cliente")]
        public void CreateCliente_WithInvalidTelefone_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Cliente("Client Name", "12345678901", ""));

            Assert.Equal("O telefone é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Cliente")]
        public void UpdateCliente_WithValidData_ReturnsCliente()
        {
            var cliente = new Cliente("Client Name", "12345678901", "11987654321");

            cliente.Update("New Name", "12345678902", "11987654322");

            Assert.Equal("New Name", cliente.Nome);
            Assert.Equal("12345678902", cliente.CPF);
            Assert.Equal("11987654322", cliente.Telefone);
        }


        [Fact]
        [Trait("Domain", "Update Cliente")]
        public void UpdateCliente_WithInvalidName_ThrowsDomainExceptionValidation()
        {
            var cliente = new Cliente("Client Name", "12345678901", "11987654321");

            var exception = Assert.Throws<DomainExceptionValidation>(() => cliente.Update("", "12345678902", "11987654322"));

            Assert.Equal("O nome é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Cliente")]
        public void UpdateCliente_WithInvalidCPF_ThrowsDomainExceptionValidation()
        {

            var cliente = new Cliente("Client Name", "12345678901", "11987654321");

            var exception = Assert.Throws<DomainExceptionValidation>(() => cliente.Update("Client Name", "", "11987654322"));

            Assert.Equal("O cpf é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Cliente")]
        public void UpdateCliente_WithInvalidTelefone_ThrowsDomainExceptionValidation()
        {
            var cliente = new Cliente("Client Name", "12345678901", "11987654321");

            var exception = Assert.Throws<DomainExceptionValidation>(() => cliente.Update("Client Name", "12345678901", ""));

            Assert.Equal("O telefone é obrigatório", exception.Message);
        }


        [Fact]
        [Trait("Domain", "DeActive Cliente")]
        public void DeActive_WhenCalled_SetsIsActiveToFalseAndUpdateDate()
        {
            var cliente = new Cliente("Client Name", "12345678901", "11987654321");

            cliente.DeActive();

            Assert.False(cliente.IsActive);
            Assert.True(cliente.UpdatedAt > DateTime.Now.AddSeconds(-1));
        }

    }
}