using intelectah.Application.Record;
using intelectah.Application.Services.Interfaces;
using intelectah.Domain.Entities;
using MediatR;
using System.Globalization;

namespace intelectah.Application.Services
{
    public class DashboardService : IDashboardService
    {
        private readonly IMediator _mediator;

        public DashboardService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public List<RecentActivityRecord> GetRecentActivitiesAsync(IList<Veiculo> veiculos, IList<Concessionaria> concessionarias, IList<Fabricante> fabricantes, IList<Venda> vendas)
        {
            var recentActivities = new List<RecentActivityRecord>();

            var recentConcessionaria = concessionarias.OrderByDescending(c => c.UpdatedAt).FirstOrDefault();
            if (recentConcessionaria != null)
            {
                var atividade = recentConcessionaria.UpdatedAt != recentConcessionaria.CreatedAt
                                ? "Concessionária Atualizada"
                                : "Concessionária Cadastrada";

                recentActivities.Add(new RecentActivityRecord(
                    Data: recentConcessionaria.UpdatedAt,
                    Atividade: atividade,
                    Detalhes: $"Nome: {recentConcessionaria.Nome}, Cidade: {recentConcessionaria.Cidade}"
                ));
            }

            var recentVeiculo = veiculos.OrderByDescending(v => v.UpdatedAt).FirstOrDefault();
            if (recentVeiculo != null)
            {
                var atividadeVeiculo = recentVeiculo.UpdatedAt != recentVeiculo.CreatedAt
                                       ? "Veículo atualizado"
                                       : "Veículo adicionado";

                recentActivities.Add(new RecentActivityRecord(
                    Data: recentVeiculo.UpdatedAt,
                    Atividade: atividadeVeiculo,
                    Detalhes: $"Modelo: {recentVeiculo.Modelo}, Ano: {recentVeiculo.AnoFabricacao}"
                ));
            }

            var recentFabricante = fabricantes.OrderByDescending(f => f.UpdatedAt).FirstOrDefault();

            if (recentFabricante != null)
            {
                var atividadeFabricante = recentFabricante.UpdatedAt != recentFabricante.CreatedAt
                                          ? "Fabricante atualizado"
                                          : "Fabricante cadastrado";

                recentActivities.Add(new RecentActivityRecord(
                    Data: recentFabricante.UpdatedAt,
                    Atividade: atividadeFabricante,
                    Detalhes: $"Nome: {recentFabricante.Nome}, Website: {recentFabricante.Website}"
                ));
            }

            var recenteVenda = vendas.OrderByDescending(v => v.UpdatedAt).FirstOrDefault();

            if (recenteVenda != null)
            {

                recentActivities.Add(new RecentActivityRecord(
                    Data: recenteVenda.UpdatedAt,
                    Atividade: "Venda realizada",
                    Detalhes: $"Preço: {recenteVenda.PrecoVenda.ToString("C", new CultureInfo("pt-BR"))}, Cliente: {recenteVenda.Cliente.Nome}"
                ));
            }

            return recentActivities.OrderByDescending(a => a.Data).ToList();
        }
    }
}
