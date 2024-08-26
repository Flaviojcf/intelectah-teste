namespace intelectah.Domain.Exceptions
{
    public class FabricanteNotFoundException : Exception
    {
        public FabricanteNotFoundException(int id) : base($"O fabricante com o id '{id}' não foi encontrado.") { }

    }
}
