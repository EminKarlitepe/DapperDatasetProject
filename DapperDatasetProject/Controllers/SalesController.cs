using DapperDatasetProject.DTOs;
using DapperDatasetProject.Services;
using Microsoft.AspNetCore.Mvc;

namespace DapperDatasetProject.Controllers
{
    public class SalesController : Controller
    {
        private readonly SalesService _salesService;
        
        public SalesController(SalesService salesService)
        {
            _salesService = salesService;
        }

        public async Task<IActionResult> Dashboard()
        {
            var dashboardStats = await _salesService.GetDashboardStatsAsync();
            return View(dashboardStats);
        }

        public async Task<IActionResult> List(string productName = "", string category = "", string customerName = "", string region = "", string city = "")
        {
            var sales = await _salesService.GetSalesWithFilterAsync(productName, category, customerName, region, city);
            ViewBag.Filter = new { productName, category, customerName, region, city };
            return View(sales);
        }
    }
}
