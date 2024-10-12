using Azure;
using Budget.Mvc.Models;
using Microsoft.EntityFrameworkCore;

namespace Budget.Mvc.Data
{
    public class BudgetDbContext : DbContext
    {
        public BudgetDbContext(DbContextOptions<BudgetDbContext> options) : base(options)
        {

        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Transaction> Transactions { get; set; }
    }
}
