using Catalog.Persistence.Database;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Service.EventHandlers.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Service.EventHandlers
{
    public class ProductInStockUpdateStockEventHandler : INotificationHandler<ProductInStockUpdateStockCommand>
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger<ProductInStockUpdateStockEventHandler> _logger;

        public ProductInStockUpdateStockEventHandler(ApplicationDbContext context, 
            ILogger<ProductInStockUpdateStockEventHandler> logger)
        {
            _context = context;
            _logger = logger;
        }

        public async Task Handle(ProductInStockUpdateStockCommand notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("---ProductInStockUpdateStockCommand Started");

            var products = notification.Items.Select(x => x.ProductId);
            var stocks = await _context.Stocks.Where(x => products.Contains
            (x.ProductID)).ToListAsync();

            _logger.LogInformation("---Retrive products from database");

            foreach (var item in notification.Items)
            {
                var entry = stocks.SingleOrDefault(x => x.ProductID == item.ProductId);
                if (item.Action == Common.Enum.ProductInStockAction.Substrac)
                {
                    if (entry == null || item.Stock > entry.Stock)
                    {
                        //logger para monitoring
                        _logger.LogInformation($"---Product {entry.ProductID} doesn´t enough stock");
                        throw new ProductInStockUpdateStockCommandException($"---Product {entry.ProductID} doesn´t enough stock");
                    }

                    entry.Stock -= item.Stock;

                    _logger.LogInformation($"---Product {entry.ProductID} its stock was subtracted and its new stock is {entry.Stock}");
                }
                else
                {
                    if (entry == null)
                    {
                        entry = new Domain.ProductInStock
                        {
                            ProductID = item.ProductId
                        };
                        await _context.Stocks.AddAsync(entry);

                        _logger.LogInformation($"---New stock record was created for {entry.ProductID}");
                    }
                    entry.Stock += item.Stock;
                    _logger.LogInformation($"---Add stock to product {entry.ProductID}");
                }
            }
            await _context.SaveChangesAsync();
        }
    }
}