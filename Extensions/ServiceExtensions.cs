using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Swashbuckle.AspNetCore.Swagger;
using System.Text;
using System.Linq;
using System.Collections.Generic;
using DAD_Parking___Back.Contracts;
using DAD_Parking___Back.Repository;
using Microsoft.AspNetCore.Identity;

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
                            .AllowAnyMethod()                            
                            .WithHeaders("authorization", "content-type");
                });
            });            
        }

        public static void ConfigureRepositoryWrapper(this IServiceCollection services)
        {
            services.AddScoped<IRepositoryWrapper, RepositoryWrapper>();
        }

        public static void ConfigurePasswordPolicies(this IServiceCollection services)
        {
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 5;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredUniqueChars = 0;
            });
        }

        public static void ConfigureSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info { Title = "DAD Parking", Version = "v1"});
                c.AddSecurityDefinition("Bearer", new ApiKeyScheme { In = "header", Description = "Please enter JWT with Bearer into field", Name = "Authorization", Type = "apiKey"});
                c.AddSecurityRequirement(new Dictionary<string, IEnumerable<string>> {
                    { "Bearer", Enumerable.Empty<string>() }
                });
            });          
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