using System;
using Catalog.Domain;
using Catalog.Persistence.Database;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;


namespace Catalog.Services.Queries
{
    public interface IProductInStockQueryService
    {
        Task<DataCollection<ProductInStockDTO>> GetAllAsync(int page, int take, IEnumerable<int> products = null);
    }

    public class ProductInStockQueryService : IProductInStockQueryService
    {
        private readonly ApplicationDbContext _context;

        public ProductInStockQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<ProductInStockDTO>> GetAllAsync(int page, int take, IEnumerable<int> products = null)
        {
            var collection = await _context.Stocks
               .Where(x => products == null || products.Contains(x.ProductID))
               .OrderByDescending(x => x.ProductID)
               .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductInStockDTO>>();
        }
    }
}
