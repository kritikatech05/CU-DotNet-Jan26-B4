using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCatalog.Services.DTOs
{
    public class CategorySummaryDto
    {
        public string CategoryName { get; set; } = string.Empty;
        public int ProductCount { get; set; }
        public decimal AvgPrice { get; set; }
        public string? MostExpensiveProduct { get; set; }
    }
}
