using Microsoft.EntityFrameworkCore;
using SmartBank.TransactionService.Models;

public class TransactionDbContext : DbContext
{
    public TransactionDbContext(DbContextOptions<TransactionDbContext> options)
        : base(options) { }

    public DbSet<Transaction> Transactions { get; set; }
}