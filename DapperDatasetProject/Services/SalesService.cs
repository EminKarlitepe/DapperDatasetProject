using Dapper;
using DapperDatasetProject.Context;
using DapperDatasetProject.DTOs;

namespace DapperDatasetProject.Services
{
    public class SalesService : ISalesService
    {
        private readonly DapperContext _dapperContext;

        public SalesService(DapperContext dapperContext)
        {
            _dapperContext = dapperContext;
        }

        public async Task<List<SalesDto>> GetAllSalesAsync()
        {
            string query = "SELECT TOP 1000 * FROM SALES";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<SalesDto>(query);
            return values.ToList();
        }

        public async Task<List<SalesDto>> GetSalesWithFilterAsync(string productName = "", string category = "", string customerName = "", string region = "", string city = "")
        {
            var whereConditions = new List<string>();
            var parameters = new DynamicParameters();

            if (!string.IsNullOrEmpty(productName))
            {
                whereConditions.Add("ITEMNAME LIKE @ProductName");
                parameters.Add("@ProductName", $"%{productName}%");
            }

            if (!string.IsNullOrEmpty(category))
            {
                whereConditions.Add("CATEGORY1 = @Category");
                parameters.Add("@Category", category);
            }

            if (!string.IsNullOrEmpty(customerName))
            {
                whereConditions.Add("NAMESURNAME LIKE @CustomerName");
                parameters.Add("@CustomerName", $"%{customerName}%");
            }

            if (!string.IsNullOrEmpty(region))
            {
                whereConditions.Add("REGION = @Region");
                parameters.Add("@Region", region);
            }

            if (!string.IsNullOrEmpty(city))
            {
                whereConditions.Add("CITY = @City");
                parameters.Add("@City", city);
            }

            var whereClause = whereConditions.Count > 0 ? "WHERE " + string.Join(" AND ", whereConditions) : "";
            string query = $"SELECT TOP 1000 * FROM SALES {whereClause} ORDER BY DATE_ DESC";
            var connection = _dapperContext.CreateConnection();
            var values = await connection.QueryAsync<SalesDto>(query, parameters);
            return values.ToList();
        }

        public async Task<DashboardStatsDto> GetDashboardStatsAsync()
        {
            var connection = _dapperContext.CreateConnection();
            var stats = new DashboardStatsDto();

            stats.TotalSales = await connection.QuerySingleAsync<decimal>("SELECT SUM(TOTALPRICE) FROM SALES");
            stats.TotalOrders = await connection.QuerySingleAsync<int>("SELECT COUNT(*) FROM SALES");
            stats.AverageOrderValue = await connection.QuerySingleAsync<decimal>("SELECT AVG(TOTALPRICE) FROM SALES");
            stats.TotalCustomers = await connection.QuerySingleAsync<int>("SELECT COUNT(DISTINCT NAMESURNAME) FROM SALES");
            stats.AverageItemsPerOrder = await connection.QuerySingleAsync<decimal>("SELECT AVG(AMOUNT) FROM SALES");
            stats.UniqueProducts = await connection.QuerySingleAsync<int>("SELECT COUNT(DISTINCT ITEMID) FROM SALES");
            stats.UniqueCategories = await connection.QuerySingleAsync<int>("SELECT COUNT(DISTINCT CATEGORY1) FROM SALES");
            stats.UniqueBrands = await connection.QuerySingleAsync<int>("SELECT COUNT(DISTINCT BRAND) FROM SALES");
            stats.UniqueRegions = await connection.QuerySingleAsync<int>("SELECT COUNT(DISTINCT REGION) FROM SALES");
            stats.UniqueCities = await connection.QuerySingleAsync<int>("SELECT COUNT(DISTINCT CITY) FROM SALES");
            stats.TotalAddresses = await connection.QuerySingleAsync<int>("SELECT COUNT(DISTINCT ADDRESSID) FROM SALES");

            stats.TopCategories = (await connection.QueryAsync<CategorySalesDto>(
                "SELECT TOP 5 CATEGORY1 AS Category, SUM(TOTALPRICE) AS TotalSales, COUNT(*) AS OrderCount FROM SALES GROUP BY CATEGORY1 ORDER BY TotalSales DESC")).ToList();

            stats.RegionSales = (await connection.QueryAsync<RegionSalesDto>(
                "SELECT TOP 10 REGION, SUM(TOTALPRICE) AS TotalSales, COUNT(*) AS OrderCount FROM SALES GROUP BY REGION ORDER BY TotalSales DESC")).ToList();

            stats.TopBrands = (await connection.QueryAsync<BrandSalesDto>(
                "SELECT TOP 5 BRAND, SUM(TOTALPRICE) AS TotalSales, COUNT(*) AS OrderCount FROM SALES GROUP BY BRAND ORDER BY TotalSales DESC")).ToList();

            stats.GenderSales = (await connection.QueryAsync<GenderSalesDto>(
                "SELECT USERGENDER AS Gender, SUM(TOTALPRICE) AS TotalSales, COUNT(*) AS OrderCount FROM SALES GROUP BY USERGENDER")).ToList();

            stats.CitySales = (await connection.QueryAsync<CitySalesDto>(
                "SELECT TOP 10 CITY, SUM(TOTALPRICE) AS TotalSales, COUNT(*) AS OrderCount FROM SALES GROUP BY CITY ORDER BY TotalSales DESC")).ToList();

            stats.TopProducts = (await connection.QueryAsync<ProductSalesDto>(
                "SELECT TOP 10 ITEMNAME AS ProductName, SUM(TOTALPRICE) AS TotalSales, COUNT(*) AS OrderCount FROM SALES GROUP BY ITEMNAME ORDER BY TotalSales DESC")).ToList();

            stats.DistrictSales = (await connection.QueryAsync<DistrictSalesDto>(
                "SELECT TOP 10 DISTRICT, SUM(TOTALPRICE) AS TotalSales, COUNT(*) AS OrderCount FROM SALES GROUP BY DISTRICT ORDER BY TotalSales DESC")).ToList();

            return stats;
        }
    }
}
