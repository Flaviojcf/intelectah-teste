using MediatR;

namespace intelectah.Application.Commands.ConcessionariaCommands.CreateConcessionaria
{
    public class CreateConcessionariaCommand(string nome, string endereco, string cidade, string estado, string cep, string telefone, string email, int capacidadeMaximaVeiculos) : IRequest<int>
    {
        public string Nome { get; set; } = nome;
        public string Endereco { get; set; } = endereco;
        public string Cidade { get; set; } = cidade;
        public string Estado { get; set; } = estado;
        public string CEP { get; set; } = cep;
        public string Telefone { get; set; } = telefone;
        public string Email { get; set; } = email;
        public int CapacidadeMaximaVeiculos { get; set; } = capacidadeMaximaVeiculos;
    }
}
