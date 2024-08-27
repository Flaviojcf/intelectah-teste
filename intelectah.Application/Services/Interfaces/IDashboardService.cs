using intelectah.Application.Record;
using intelectah.Domain.Entities;

namespace intelectah.Application.Services.Interfaces
{
    public interface IDashboardService
    {
        List<RecentActivityRecord> GetRecentActivitiesAsync(IList<Veiculo> veiculos, IList<Concessionaria> concessionarias, IList<Fabricante> fabricantes, IList<Venda> vendas);
    }
}
