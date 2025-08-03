using DapperDatasetProject.DTOs;

namespace DapperDatasetProject.Services
{
    public interface ISalesService
    {
        Task<List<SalesDto>> GetAllSalesAsync();
        Task<List<SalesDto>> GetSalesWithFilterAsync(string productName = "", string category = "", string customerName = "", string region = "", string city = "");
        Task<DashboardStatsDto> GetDashboardStatsAsync();
    }
}
