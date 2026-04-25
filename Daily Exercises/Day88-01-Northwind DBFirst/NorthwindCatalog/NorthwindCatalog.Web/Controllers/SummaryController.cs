using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Services.DTOs;

namespace NorthwindCatalog.Web.Controllers
{
    public class SummaryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public SummaryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient("NorthwindApi");

            var summary = await client.GetFromJsonAsync<List<CategorySummaryDto>>(
                "api/products/summary");

            return View(summary);
        }
    }
}