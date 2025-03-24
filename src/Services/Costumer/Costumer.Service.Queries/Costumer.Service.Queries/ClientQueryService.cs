using Costumer.Service.Queries.DTOs;
using Customer.Persistence.DataBase;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Sevice.Queries
{
    // Paso6. Interfaz de ClientQueryService; Declaramos los metodos despues de crear la carpeta DTO y DataCollection creamos la interfaz
    public interface IClientQueryService
    {
        // Paso7. Referenciar a Service.Common.Collection y Customer.Sevice.Queries.DTO
        Task<DataCollection<ClientDTO>> GetAllASync(int page, int take, IEnumerable<int> clients = null);
        Task<ClientDTO> GetAsync(int id);
    }

    // Paso1. ClientQueryService; Despues heredamos de IClientQueryService
    public class ClientQueryService : IClientQueryService
    {
        // Paso2. Inyectar el contexto de la base de datos de ApplicationDbContext (Customer.Persistence.DataBase)
        private readonly ApplicationDbContext _context;

        // Paso3. Constructor que recibe el contexto de la base de datos
        public ClientQueryService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Paso4. Implementar el metodo GetAllASync;  Devuelve una coleccion de clientes
        public async Task<DataCollection<ClientDTO>> GetAllASync(int page, int take, IEnumerable<int> clients = null)
        {
            var collection = await _context.Clients
                .Where(x => clients == null || clients.Contains(x.ClientId))
                .OrderBy(x => x.Name)
                .GetPagedAsync(page, take); // Referenciar a Service.CommonPaging

            return collection.MapTo<DataCollection<ClientDTO>>(); // Referenciar a Service.Common.Mapping
        }

        // Paso5. Implementar el metodo GetAsync; Devuelve un solo cliente
        public async Task<ClientDTO> GetAsync(int id)
        {
            return (await _context.Clients.SingleAsync(x => x.ClientId == id)).MapTo<ClientDTO>();
        }
    }
}
