using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Catalog.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Catalog.Persistence.Database.Config
{
    public class ProductInStockConfiguration
    {
        public ProductInStockConfiguration(EntityTypeBuilder<ProductInStock> entityBuilder) 
        { 
            entityBuilder.HasKey(x => x.IDProductInStock);
            var products = new List<ProductInStock>();
            var random = new Random();

            for (int i = 1; i <= 100; i++)
            {
                products.Add(new ProductInStock
                {
                    IDProductInStock = i,
                    ProductID = i,
                    Stock = random.Next(0, 20),
                });
            }
            entityBuilder.HasData(products);
        }
    }
}
