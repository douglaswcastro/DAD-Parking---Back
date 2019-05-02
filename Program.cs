using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace DAD_Parking___Back
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) {
            var assemblyName = typeof(Startup).GetTypeInfo().Assembly.FullName;
            
            return WebHost.CreateDefaultBuilder(args)
                .UseStartup(assemblyName)
                .UseUrls("http://localhost:5000");
        }
    }
}
