using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Persistence.Database;
using Order.Service.Queries.DTOs;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;

namespace Order.Service.Queries
{
    public interface IOrderQueryService
    {
        Task<DataCollection<OrderDTO>> GetAllASync(int page, int take, IEnumerable<int> orders = null);
        Task<OrderDTO> GetAsync(int id);
    }

    public class OrderQueryService : IOrderQueryService
    {
        private readonly ApplicationDbContext _context;

        public OrderQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Crear nuestras colecciones
        //Inicializa en null porque no quiere mandarle Orderos, si no que los traiga de tantos en tantos
        public async Task<DataCollection<OrderDTO>> GetAllASync(int page, int take, IEnumerable<int> orders = null)
        {
            var collection = await _context.Orders
                .Where(x => orders == null || orders.Contains(x.OrderId))
                .OrderByDescending(x => x.OrderId)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<OrderDTO>>();
        }

        public async Task<OrderDTO> GetAsync(int id)
        {
            return (await _context.Orders
                .SingleAsync(x => x.OrderId == id))
                .MapTo<OrderDTO>();
        }
    }

}

