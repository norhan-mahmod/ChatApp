using System.Text;
using Chatify.Core.Entities;
using Chatify.Core.Services;
using Chatify.Repository.Data;
using Chatify.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace Chatify.API.Extensions
{
    public static class IdentityServiceExtension 
    {
        public static IServiceCollection AddIdentityService(this IServiceCollection services , IConfiguration config)
        {
            services.AddIdentity<ApplicationUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireLowercase = true;
                options.Password.RequireUppercase = true;
                options.Password.RequireNonAlphanumeric = true;
            }).AddEntityFrameworkStores<AppDbContext>().AddDefaultTokenProviders();

            services.AddScoped<ITokenService, TokenService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidIssuer = config["Jwt:Issuer"],
                    ValidateAudience = true,
                    ValidAudience = config["Jwt:Audience"],
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["Jwt:Key"]))
                };

                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        var token = context.Request.Cookies["AuthToken"];
                        if (!string.IsNullOrEmpty(token))
                            context.Token = token;
                        return Task.CompletedTask;
                    }
                };
            });

            return services;
        }
    }
}
