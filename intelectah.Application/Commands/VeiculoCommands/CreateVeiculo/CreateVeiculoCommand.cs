using intelectah.Domain.TypesEnum;
using MediatR;

namespace intelectah.Application.Commands.VeiculoCommands.CreateVeiculo
{
    public class CreateVeiculoCommand(string modelo, int anoFabricacao, decimal preco, TipoVeiculo tipoVeiculo, string descricao, int fabricanteID) : IRequest<int>
    {
        public string Modelo { get; set; } = modelo;
        public int AnoFabricacao { get; set; } = anoFabricacao;
        public decimal Preco { get; set; } = preco;
        public TipoVeiculo TipoVeiculo { get; set; } = tipoVeiculo;
        public string Descricao { get; set; } = descricao;
        public int FabricanteID { get; set; } = fabricanteID;
    }
}
