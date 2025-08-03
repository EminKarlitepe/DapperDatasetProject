namespace DapperDatasetProject.DTOs
{
    public class SalesDto
    {
        public int ID { get; set; }
        public int ORDERID { get; set; }
        public int ORDERDETAILID { get; set; }
        public DateTime DATE_ { get; set; }
        public int USERID { get; set; }
        public string? USERNAME_ { get; set; }
        public string? NAMESURNAME { get; set; }
        public string? STATUS_ { get; set; }
        public int ITEMID { get; set; }
        public string? ITEMCODE { get; set; }
        public string? ITEMNAME { get; set; }
        public decimal AMOUNT { get; set; }
        public decimal UNITPRICE { get; set; }
        public decimal PRICE { get; set; }
        public decimal TOTALPRICE { get; set; }
        public string? CATEGORY1 { get; set; }
        public string? CATEGORY2 { get; set; }
        public string? CATEGORY3 { get; set; }
        public string? CATEGORY4 { get; set; }
        public string? BRAND { get; set; }
        public string? USERGENDER { get; set; }
        public DateTime? USERBIRTHDATE { get; set; }
        public string? REGION { get; set; }
        public string? CITY { get; set; }
        public string? TOWN { get; set; }
        public string? DISTRICT { get; set; }
        public string? ADDRESSTEXT { get; set; }
        public int ADDRESSID { get; set; }
    }

    public class DashboardStatsDto
    {
        public decimal TotalSales { get; set; }
        public int TotalOrders { get; set; }
        public decimal AverageOrderValue { get; set; }
        public int TotalCustomers { get; set; }
        public decimal AverageItemsPerOrder { get; set; }
        public int UniqueProducts { get; set; }
        public int UniqueCategories { get; set; }
        public int UniqueBrands { get; set; }
        public int UniqueRegions { get; set; }
        public int UniqueCities { get; set; }
        public int TotalAddresses { get; set; }
        public List<CategorySalesDto> TopCategories { get; set; } = new();
        public List<RegionSalesDto> RegionSales { get; set; } = new();
        public List<BrandSalesDto> TopBrands { get; set; } = new();
        public List<GenderSalesDto> GenderSales { get; set; } = new();
        public List<CitySalesDto> CitySales { get; set; } = new();
        public List<ProductSalesDto> TopProducts { get; set; } = new();
        public List<DistrictSalesDto> DistrictSales { get; set; } = new();
    }

    public class CategorySalesDto
    {
        public string Category { get; set; } = string.Empty;
        public decimal TotalSales { get; set; }
        public int OrderCount { get; set; }
    }

    public class RegionSalesDto
    {
        public string Region { get; set; } = string.Empty;
        public decimal TotalSales { get; set; }
        public int OrderCount { get; set; }
    }

    public class BrandSalesDto
    {
        public string Brand { get; set; } = string.Empty;
        public decimal TotalSales { get; set; }
        public int OrderCount { get; set; }
    }

    public class GenderSalesDto
    {
        public string Gender { get; set; } = string.Empty;
        public decimal TotalSales { get; set; }
        public int OrderCount { get; set; }
    }

    public class CitySalesDto
    {
        public string City { get; set; } = string.Empty;
        public decimal TotalSales { get; set; }
        public int OrderCount { get; set; }
    }



    public class ProductSalesDto
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal TotalSales { get; set; }
        public int OrderCount { get; set; }
    }

    public class DistrictSalesDto
    {
        public string District { get; set; } = string.Empty;
        public decimal TotalSales { get; set; }
        public int OrderCount { get; set; }
    }

    public class SalesFilterDto
    {
        public string? ProductName { get; set; }
        public string? Category { get; set; }
        public string? CustomerName { get; set; }
        public string? Region { get; set; }
        public string? City { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int Page { get; set; } = 1;
        public int PageSize { get; set; } = 50;
    }
}
