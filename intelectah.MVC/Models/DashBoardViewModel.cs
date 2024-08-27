using intelectah.Application.Record;

namespace intelectah.MVC.Models
{
    public class DashBoardViewModel
    {
        public int TotalVeiculos { get; set; }
        public int TotalConcessionarias { get; set; }
        public int TotalVendas { get; set; }
        public int TotalFabricantes { get; set; }

        public List<RecentActivityRecord> RecentActivities { get; set; } = [];
    }
}
