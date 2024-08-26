namespace intelectah.Domain.Exceptions
{
    public class FabricanteAlreadyExistException : Exception
    {
        public FabricanteAlreadyExistException(string nome) : base($"O fabricante com o nome '{nome}' já existe.") { }

    }
}
