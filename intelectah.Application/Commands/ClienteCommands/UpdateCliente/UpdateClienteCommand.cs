using MediatR;

namespace intelectah.Application.Commands.ClienteCommands.UpdateCliente
{
    public class UpdateClienteCommand(int id, string nome, string cpf, string telefone) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
        public string Nome { get; set; } = nome;
        public string CPF { get; set; } = cpf;
        public string Telefone { get; set; } = telefone;
    }
}
