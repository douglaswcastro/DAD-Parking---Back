using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using DAD_Parking___Back.Data;
using DAD_Parking___Back.Extensions;

namespace DAD_Parking___Back
{
    public class Startup
    {
        public Startup(IConfiguration configuration) 
        {
            Configuration = configuration;            
        }
        public IConfiguration Configuration { get; }
    
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            //Using In Memory Database until SQL Server is not configured
            //services.AddDbContext<DADParkingDbContext>(options => options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));            
            services.AddDbContext<DADParkingDbContext>(options =>
               options.UseSqlServer(
                   Configuration.GetConnectionString("dad_parking")));
            
            services.AddIdentity<DADParkingUser, IdentityRole>()
                .AddEntityFrameworkStores<DADParkingDbContext>()
                .AddDefaultTokenProviders();            

            services.ConfigureCors();            
            services.ConfigureRepositoryWrapper();
            services.ConfigureAuthentication();                  
            services.ConfigureSwagger();      
            services.ConfigurePasswordPolicies();

            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {          
            SeedDatabase.Initialize(app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope().ServiceProvider);
            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {                
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "DAD Parking");
            });
            app.UseMvc();
        }
    }
}
