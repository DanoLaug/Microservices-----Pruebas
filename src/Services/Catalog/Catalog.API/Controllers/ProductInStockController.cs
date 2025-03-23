using Catalog.Domain;
using Catalog.Service.EventHandlers.Commands;
using Catalog.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;


namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("stocks")]
    public class ProductInStockController : ControllerBase
    {
        private readonly IProductInStockQueryService _productInStockService;
        private readonly IMediator _mediator;

        public ProductInStockController(IProductInStockQueryService productInStockService, IMediator mediator)
        {
            _productInStockService = productInStockService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<ProductInStockDTO>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> products = null;
            if (!string.IsNullOrEmpty(ids))
            {
                products = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _productInStockService.GetAllAsync(page, take, products);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock(ProductInStockUpdateStockCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }
    }
}