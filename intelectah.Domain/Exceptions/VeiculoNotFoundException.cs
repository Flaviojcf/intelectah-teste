namespace intelectah.Domain.Exceptions
{

    namespace intelectah.Domain.Exceptions
    {
        public class VeiculoNotFoundException : Exception
        {
            public VeiculoNotFoundException(int id) : base($"O veiculo com o id '{id}' não foi encontrado.") { }

        }
    }

}
