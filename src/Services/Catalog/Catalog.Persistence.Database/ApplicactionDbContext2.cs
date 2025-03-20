using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Catalog.Persistence.Database
{
    public class ApplocationDbContext : DbContext
    {
        class ApplicactionDbContext(DbContextOptions<ApplicactionDbContext> options) : base(Options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductInStock> Stocks { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.HasDefaultSchema("Catalog");
            ModelConfig(modelBuilder);
        }

        private void ModelConfig(ModelBuilder modelBuilder)
        {

        }
    }
} 
