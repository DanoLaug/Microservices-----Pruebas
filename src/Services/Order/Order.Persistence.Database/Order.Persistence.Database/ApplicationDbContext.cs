﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Order.Domain;
using Order.Persistence.Database.Configuration;

namespace Order.Persistence.Database
{
    public class ApplicationDbContext  : DbContext
    {
        public ApplicationDbContext(
           DbContextOptions<ApplicationDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        { 
            base.OnModelCreating(modelBuilder);
            
            //Database schema
            modelBuilder.HasDefaultSchema("Order");
            
            //Model Contraints
            ModelConfig(modelBuilder);
        }

        public DbSet<Domain.Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }

        private void ModelConfig(ModelBuilder modelBuilder)
        {
            new OrderConfiguration(modelBuilder.Entity<Domain.Order>());
            new OrderDetailConfiguration(modelBuilder.Entity<OrderDetail>());
        }
    }
}
