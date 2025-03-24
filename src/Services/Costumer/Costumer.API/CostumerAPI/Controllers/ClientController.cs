using Costumer.Service.Queries.DTOs;
using Customer.Service.EventHandler.Commands;
using Customer.Sevice.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Service.Common.Collection;

namespace Customer.API.Controllers
{
    // Agregar la ruta de la API
    [ApiController]
    [Route("clients")]
    public class ClientController : ControllerBase
    {
        // Paso1. Inyectar las interfaces (Referenciar a Customer.Service.Queries); Instalar MediatR
        private readonly IClientQueryService _clientQueryService;
        private readonly ILogger<ClientController> _logger;
        private readonly IMediator _mediator;

        // Paso2. Constructor que recibe las interfaces
        public ClientController(IClientQueryService clientQueryService, ILogger<ClientController> logger, IMediator mediator)
        {
            _clientQueryService = clientQueryService;
            _logger = logger;
            _mediator = mediator;
        }

        // Paso3. Crear el metodo Get para obtener todos los clientes (Referenciar a Service.Common.Collection y al DTO) 
        [HttpGet]
        public async Task<DataCollection<ClientDTO>> GetAll(int page = 1, int take = 10, string ids = null)
        {
            IEnumerable<int> clients = null;
            if (!string.IsNullOrEmpty(ids))
            {
                clients = ids.Split(',').Select(x => Convert.ToInt32(x));
            }
            return await _clientQueryService.GetAllASync(page, take, clients);
        }

        // Paso4. Crear el metodo Get para obtener un cliente por ID
        [HttpGet("{id}")]
        public async Task<ClientDTO> Get(int id)
        {
            return await _clientQueryService.GetAsync(id);
        }

        // Paso5. Crear el metodo Post para crear un cliente (Referenciar a Customer.Service.EventHandler.Commands)
        public async Task<IActionResult> Create(ClientCreateCommand command)
        {
            await _mediator.Publish(command);
            return Ok();
        }
    }
}