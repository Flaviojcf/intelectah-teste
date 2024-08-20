using MediatR;

namespace intelectah.Application.Commands.ClienteCommands.CreateCliente
{
    public class CreateClienteCommand(string nome, string cpf, string telefone) : IRequest<int>
    {
        public string Nome { get; set; } = nome;
        public string CPF { get; set; } = cpf;
        public string Telefone { get; set; } = telefone;
    }
}
