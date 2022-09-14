using Microsoft.EntityFrameworkCore;
using Models.Entities;

namespace DataAccess.Data
{
    public class ECommerceDbContext : DbContext
    {
        public ECommerceDbContext(DbContextOptions<ECommerceDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder opitionsBuilder)
        {
            if (!opitionsBuilder.IsConfigured)
            {
                opitionsBuilder.UseSqlServer("Data Source=AbhishekSahai;Initial Catalog=ECommerce;Persist Security Info=True;User ID=sahai;Password=Anaya@300618;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public DbSet<Product> Products { get; set; }
    }
}