using NorthwindCatalog.Services.DTOs;
using NorthwindCatalog.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCatalog.Services.Interfaces
{
    public interface IProductRepository
    {
        Task<IEnumerable<Product>> GetByCategoryIdAsync(int categoryId);
        Task<IEnumerable<CategorySummaryDto>> GetCategorySummariesAsync();
    }
}
