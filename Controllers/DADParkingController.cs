using System;
using System.Collections.Generic;
using System.Linq;
using DAD_Parking___Back.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DAD_Parking___Back.Controllers
{    
    [ApiController]
    [Route("api/[controller]")]
    public class DADParkingController : ControllerBase
    {
        private DADParkingDbContext context;

        public DADParkingController(DADParkingDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public IEnumerable<string> GetUsers()
        {
            return context.Users.Select(u => u.UserName).ToArray();
        } 
    }
}
