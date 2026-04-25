using Microsoft.AspNetCore.Mvc;
using NorthwindCatalog.Services.DTOs;

namespace NorthwindCatalog.Web.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> ByCategory(int id)
        {
            var client = _httpClientFactory.CreateClient("NorthwindApi");

            var products = await client.GetFromJsonAsync<List<ProductDto>>(
                $"api/products/by-category/{id}");

            return View(products);
        }
    }
}