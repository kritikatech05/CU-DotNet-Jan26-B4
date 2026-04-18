using Microsoft.EntityFrameworkCore;
using NorthwindCatalog.Services.Data;
using NorthwindCatalog.Services.Interfaces;
using NorthwindCatalog.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NorthwindCatalog.Services.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly NorthwindContext _context;

        public CategoryRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Category>> GetAllAsync()
        {
            return await _context.Categories.ToListAsync();
        }
    }
}
