namespace intelectah.Domain.Exceptions
{

    public class ConcessionariaAlreadyExistException : Exception
    {
        public ConcessionariaAlreadyExistException(string nome) : base($"A concessionária com o nome '{nome}' já existe.") { }

    }
}
