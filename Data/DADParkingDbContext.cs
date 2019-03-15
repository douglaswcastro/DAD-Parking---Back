using System;
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
    }
}