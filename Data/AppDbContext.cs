using Microsoft.EntityFrameworkCore;
using NumberApi.Models;

namespace NumberApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<NumItem> Numbers => Set<NumItem>();
    }
}