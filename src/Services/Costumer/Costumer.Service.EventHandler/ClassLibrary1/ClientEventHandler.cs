using Customer.Domain;
using Customer.Persistence.DataBase;
using Customer.Service.EventHandler.Commands;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Service.EventHandler
{
    // Paso1. Implementar la interfaz INotificationHandler<ClientCreateCommand> (Referenciar a MediatR y ../Commands)
    public class ClientEventHandler : INotificationHandler<ClientCreateCommand>
    {
        // Paso2. Inyectar el contexto de la base de datos de ApplicationDbContext (Customer.Persistence.DataBase)
        private readonly ApplicationDbContext _context;

        // Paso3. Constructor que recibe el contexto de la base de datos
        public ClientEventHandler(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Handle(ClientCreateCommand notification, CancellationToken cancellationToken)
        {
            await _context.AddAsync(new Client
            {
                Name = notification.Name
            });
            await _context.SaveChangesAsync();
        }
    }
}