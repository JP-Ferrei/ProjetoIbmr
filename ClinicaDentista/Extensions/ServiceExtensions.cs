using System;
using System.Text;
using Data.Interface.Geral;
using Data.Repository.Geral;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Service.Interface.Geral;
using Service.Services.Geral;

namespace ClinicaDentista.Extensions
{
    public static class ServiceExtensions
    {

        public static void AddInjections(this IServiceCollection services)
        {

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioService, UsuarioService>();
        }

        public static void AddJwt(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = false;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(configuration["JwtKey"])),
                    ValidIssuer = configuration["JwtIssuer"],
                    ValidAudience = configuration["JwtIssuer"],
                };
            });
        }
    }
}
