using intelectah.Domain.Entities;
using intelectah.Domain.TypesEnum;
using intelectah.Domain.Validation;

namespace intelectah.Tests.Domain
{
    [Collection(nameof(Usuario))]
    public class UsuarioUnitTest
    {
        [Fact]
        [Trait("Domain", "Create Usuario")]
        public void CreateUsuario_WithValidData_ReturnsUsuario()
        {
            var usuario = new Usuario("João", "senha123", "joao@example.com", NivelAcesso.Administrador);

            Assert.Equal("João", usuario.Nome);
            Assert.Equal("senha123", usuario.Senha);
            Assert.Equal("joao@example.com", usuario.Email);
            Assert.Equal(NivelAcesso.Administrador, usuario.NivelAcesso);
            Assert.True(usuario.IsActive);
        }

        [Fact]
        [Trait("Domain", "Create Usuario")]
        public void CreateUsuario_WithInvalidNome_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Usuario("", "senha123", "joao@example.com", NivelAcesso.Administrador));

            Assert.Equal("O nome é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Usuario")]
        public void CreateUsuario_WithInvalidEmail_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Usuario("João", "senha123", "invalid-email", NivelAcesso.Administrador));

            Assert.Equal("O e-mail deve ser válido", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Create Usuario")]
        public void CreateUsuario_WithInvalidNivelAcesso_ThrowsDomainExceptionValidation()
        {
            var exception = Assert.Throws<DomainExceptionValidation>(() => new Usuario("João", "senha123", "joao@example.com", (NivelAcesso)999));

            Assert.Equal("O nível de acesso é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Usuario")]
        public void UpdateUsuario_WithValidData_UpdatesUsuario()
        {
            var usuario = new Usuario("João", "senha123", "joao@example.com", NivelAcesso.Administrador);
            usuario.Update("Pedro", "novaSenha", "pedro@example.com", NivelAcesso.Vendedor);

            Assert.Equal("Pedro", usuario.Nome);
            Assert.Equal("novaSenha", usuario.Senha);
            Assert.Equal("pedro@example.com", usuario.Email);
            Assert.Equal(NivelAcesso.Vendedor, usuario.NivelAcesso);
        }

        [Fact]
        [Trait("Domain", "Update Usuario")]
        public void UpdateUsuario_WithInvalidNome_ThrowsDomainExceptionValidation()
        {
            var usuario = new Usuario("João", "senha123", "joao@example.com", NivelAcesso.Administrador);

            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                usuario.Update("", "novaSenha", "pedro@example.com", NivelAcesso.Vendedor));

            Assert.Equal("O nome é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Usuario")]
        public void UpdateUsuario_WithInvalidSenha_ThrowsDomainExceptionValidation()
        {
            var usuario = new Usuario("João", "senha123", "joao@example.com", NivelAcesso.Administrador);

            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                usuario.Update("Pedro", "", "pedro@example.com", NivelAcesso.Vendedor));

            Assert.Equal("A senha é obrigatória", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Usuario")]
        public void UpdateUsuario_WithInvalidEmail_ThrowsDomainExceptionValidation()
        {
            var usuario = new Usuario("João", "senha123", "joao@example.com", NivelAcesso.Administrador);

            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                usuario.Update("Pedro", "novaSenha", "invalid-email", NivelAcesso.Vendedor));

            Assert.Equal("O e-mail deve ser válido", exception.Message);
        }

        [Fact]
        [Trait("Domain", "Update Usuario")]
        public void UpdateUsuario_WithInvalidNivelAcesso_ThrowsDomainExceptionValidation()
        {
            var usuario = new Usuario("João", "senha123", "joao@example.com", NivelAcesso.Administrador);

            var exception = Assert.Throws<DomainExceptionValidation>(() =>
                usuario.Update("Pedro", "novaSenha", "pedro@example.com", (NivelAcesso)999));

            Assert.Equal("O nível de acesso é obrigatório", exception.Message);
        }

        [Fact]
        [Trait("Domain", "DeActive Usuario")]
        public void DeActive_WhenCalled_SetsIsActiveToFalseAndUpdateDate()
        {
            var usuario = new Usuario("João", "senha123", "joao@example.com", NivelAcesso.Administrador);

            usuario.DeActive();

            Assert.False(usuario.IsActive);
            Assert.True(usuario.UpdatedAt > DateTime.Now.AddSeconds(-1));
        }

    }
}
