using intelectah.Domain.TypesEnum;
using MediatR;

namespace intelectah.Application.Commands.VeiculoCommands.UpdateVeiculo
{
    public class UpdateVeiculoCommand(int id, string modelo, int anoFabricacao, decimal preco, TipoVeiculo tipoVeiculo, string descricao, int fabricanteID) : IRequest<Unit>
    {
        public int Id { get; set; } = id;
        public string Modelo { get; set; } = modelo;
        public int AnoFabricacao { get; set; } = anoFabricacao;
        public decimal Preco { get; set; } = preco;
        public TipoVeiculo TipoVeiculo { get; set; } = tipoVeiculo;
        public string Descricao { get; set; } = descricao;
        public int FabricanteID { get; set; } = fabricanteID;
    }
}
