using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Customer.Persistence.DataBase.Configuration;
using Customer.Domain;
using System.Reflection.Emit;

namespace Customer.Persistence.DataBase
{
    // Paso1. Heredamos de DbContext para poder trabajar con la base de datos (EntityFrameworkCore)
    public class ApplicationDbContext : DbContext
    {
        // Paso2. Constructor que recibe las opciones de configuración de la base de datos
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        //Paso 5 
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Paso5.1 Instalar EF sql para que el metodo jale
            modelBuilder.HasDefaultSchema("Customer");

            ModelConfig(modelBuilder);
        }

        // Paso3. ref a Customer.Domain
        public DbSet<Client> Clients { get; set; }

        // Paso4. Se crea el metodo para llamarlo  
        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new ClientConfiguration(modelBuilder.Entity<Client>());
        }
    }
}
