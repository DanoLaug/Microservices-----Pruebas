using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Order.Persistence.Database;
using Order.Service.Queries.DTOs;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;

namespace Order.Service.Queries
{
    public interface IOrderDetailQueryService
    {
        Task<DataCollection<OrderDetailDTO>> GetAllAsync(int page, int take, IEnumerable<int> orders = null);
    }

    public class OrderDetailQueryService : IOrderDetailQueryService
    {
        private readonly ApplicationDbContext _context;

        public OrderDetailQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<DataCollection<OrderDetailDTO>> GetAllAsync(int page, int take, IEnumerable<int> orders = null)
        {
            var collection = await _context.OrderDetail
               .Where(x => orders == null || orders.Contains(x.OrderDetailId))
               .OrderByDescending(x => x.OrderDetailId)
               .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<OrderDetailDTO>>();
        }
    }
}
