using Customer.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer.Persistence.DataBase.Configuration
{
    public class ClientConfiguration
    {
        //Instalar Microsoft.EntityFrameworkCore.. y Refernciar al Domain
        public ClientConfiguration(EntityTypeBuilder<Client> entityBuilder)
        {
            // Establece que campo sera la Primary Key y que campo sera requerido
            entityBuilder.HasKey(x => x.ClientId);
            entityBuilder.Property(x => x.Name).IsRequired().HasMaxLength(100);

            var clients = new List<Client>();

            // Seed para Clientes
            for (var i = 1; i <= 10; i++)
            {
                // Agregar los datos a la lista
                clients.Add(new Client
                {
                    ClientId = i,
                    Name = $"Client {i}"
                });
            }

            // Agregar los datos a la tabla
            entityBuilder.HasData(clients);
        }
    }
}
