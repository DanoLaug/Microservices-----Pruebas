using Catalog.Domain;
using Catalog.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Services.Queries
{
    public interface IProductQueryService
    {
        Task<DataCollection<ProductDTO>> GetAllASync(int page, int take, IEnumerable<int> products = null);
        Task<ProductDTO> GetAsync(int id);
    }

    public class ProductQueryService : IProductQueryService
    {
        private readonly ApplicationDbContext _context;

        public ProductQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Crear nuestras colecciones
        //Inicializa en null porque no quiere mandarle productos, si no que los traiga de tantos en tantos
        public async Task<DataCollection<ProductDTO>> GetAllASync(int page, int take, IEnumerable<int> products = null)
        {
            var collection = await _context.Products
                .Where(x => products == null || products.Contains(x.IDProduct))
                .OrderByDescending(x => x.IDProduct)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<ProductDTO>>();
        }

        public async Task<ProductDTO> GetAsync(int id)
        {
            return (await _context.Products
                .SingleAsync(x => x.IDProduct == id))
                .MapTo<ProductDTO>();
        }
    }
}