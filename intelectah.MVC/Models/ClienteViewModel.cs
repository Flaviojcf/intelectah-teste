using intelectah.Domain.Entities;

namespace intelectah.MVC.Models
{
    public class ClienteViewModel
    {
        public string? Nome { get; set; }
        public string? CPF { get; set; }
        public string? Telefone { get; set; }
        public IList<Cliente> Clientes { get; set; }
    }
}
