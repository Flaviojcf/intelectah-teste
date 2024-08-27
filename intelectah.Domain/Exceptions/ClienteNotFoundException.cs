namespace intelectah.Domain.Exceptions
{
    public class ClienteNotFoundException : Exception
    {
        public ClienteNotFoundException(int id) : base($"O cliente com o id '{id}' não foi encontrado.") { }

    }
}
