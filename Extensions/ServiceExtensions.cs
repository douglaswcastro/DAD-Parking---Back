using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Repository;

namespace DAD_Parking___Back.Extensions
{
    public static class ServiceExtenions
    {
        private const string KEY = "APPLICATION_TEST_KEY";
        public static void ConfigureCors(this IServiceCollection services)
        {
            services.AddCors(options => 
            {
                options.AddPolicy("CorsPolicy",
                builder =>
                {
                    builder.AllowAnyOrigin()
                            .WithMethods("GET", "POST")
                            .WithHeaders("authorization", "content-type");
                });
            });            
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigureAuthentication(this IServiceCollection services)
        {
            services.AddAuthentication(options => 
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options => 
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,                    
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(KEY))              
                };
            });
        }
    }
}