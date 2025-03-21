//Este es un seeder : una semilla que nos ayuda a crear nuestra base de datos
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Database.Config
{
    public class ProductConfiguration
    {
        public ProductConfiguration(EntityTypeBuilder<Product> entityBuilder)
        {
            entityBuilder.HasKey(x => x.IDProduct);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);
            entityBuilder.Property(x => x.Description).IsRequired().HasMaxLength(500);


            //Seeds
            //Products by default
            var products = new List<Product>();
            var random = new Random();

            for (var i = 1; i <= 100; i++)
            {
                products.Add(new Product
                {
                    IDProduct = i,
                    Name = $"Product {i}",
                    Description = $"Description for Product {i}",
                    Price = random.Next(100, 1000),
                });
            }
            entityBuilder.HasData(products);
        }
    }
}
