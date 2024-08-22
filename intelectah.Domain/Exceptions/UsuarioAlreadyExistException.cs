namespace intelectah.Domain.Exceptions
{
    public class UsuarioAlreadyExistException : Exception
    {
        public UsuarioAlreadyExistException(string email) : base($"O usuário com o e-mail '{email}' já existe.") { }

    }
}
