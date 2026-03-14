using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using FinTrack_Pro.Models;

namespace FinTrack_Pro.Data
{
    public class FinTrack_ProContext : DbContext
    {
        public FinTrack_ProContext (DbContextOptions<FinTrack_ProContext> options)
            : base(options)
        {
        }

        public DbSet<Transaction> Transactions { get; set; }

        public DbSet<Account> Accounts { get; set; }
        public DbSet<FinTrack_Pro.Models.Asset> Asset { get; set; }

    }
}
