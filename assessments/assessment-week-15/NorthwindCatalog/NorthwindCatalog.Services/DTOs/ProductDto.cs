using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCatalog.Services.DTOs
{
    public class ProductDto
    {
        public string ProductName { get; set; } = string.Empty;
        public decimal UnitPrice { get; set; }
        public short UnitsInStock { get; set; }

        public decimal InventoryValue => UnitPrice * UnitsInStock;
    }
}
