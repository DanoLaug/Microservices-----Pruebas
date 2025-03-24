using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Service.EventHandler.Commands
{
    // Paso1. Crear la carpeta Commands y la clase ClientCreateCommand (Instalar MediatR)
    public class ClientCreateCommand : INotification
    {
        // Unico dato que se pasa porque el ID es autoincrementable
        public string Name { get; set; }
    }
}