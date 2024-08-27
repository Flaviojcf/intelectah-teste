namespace intelectah.Domain.Exceptions
{
    public class ClienteAlreadyExistException : Exception
    {
        public ClienteAlreadyExistException(string CPF) : base($"O cliente com o CPF '{CPF}' já existe.") { }

    }
}
