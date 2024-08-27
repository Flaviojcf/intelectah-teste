namespace intelectah.Domain.Exceptions
{
    public class ConcessionariaNotFoundException : Exception
    {
        public ConcessionariaNotFoundException(int id) : base($"A concessionaria com id'{id}' não foi encontrado.") { }

    }


}
