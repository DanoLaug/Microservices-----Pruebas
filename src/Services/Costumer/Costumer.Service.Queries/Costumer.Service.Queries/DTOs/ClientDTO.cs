using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Costumer.Service.Queries.DTOs
{
    // DTO for Client; Creamos un objeto que se encargara de transportar la informacion de un cliente
    public class ClientDTO
    {
        public int ClientId { get; set; }
        public string Name { get; set; }
    }
}
