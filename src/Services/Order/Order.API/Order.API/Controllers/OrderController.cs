using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Order.Service.Queries;
using Order.Service.Queries.DTOs;
using Service.Common.Collection;


namespace Catalog.API.Controllers
{
    [ApiController]
    [Route("orders")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderQueryService _orderQueryService;
        private readonly IMediator _mediator;

        public OrderController(IOrderQueryService orderQueryService, IMediator mediator)
        {
            _orderQueryService = orderQueryService;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<DataCollection<OrderDTO>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> orders = null;
            if (!string.IsNullOrEmpty(ids))
            {
                orders = ids.Split(',').Select(x => Convert.ToInt32(x));
            }

            return await _orderQueryService.GetAllASync(page, take, orders);
        }

        [HttpGet("{id}")]
        public async Task<OrderDTO> Get(int id)
        {
            return await _orderQueryService.GetAsync(id);
        }

        //
        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();

        }
    }
}