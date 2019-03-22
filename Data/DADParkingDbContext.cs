using System;
using DAD_Parking___Back.Model;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DAD_Parking___Back.Data
{
    public class DADParkingDbContext : IdentityDbContext<DADParkingUser>
    {        
        public DADParkingDbContext(DbContextOptions<DADParkingDbContext> options) : base(options)
        {            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<Tarifa> Tarifas { get; set; }
        public DbSet<Veiculo> Veiculos { get; set; }
        public DbSet<Vinculo> Vinculos { get; set; }
        public DbSet<Vaga> Vagas { get; set; }
    }
}