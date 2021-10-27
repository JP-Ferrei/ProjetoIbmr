using System;
using System.Text;
using System.Threading.Tasks;
using ClinicaDentista.Provider;
using Data.Interface.Geral;
using Data.Interface.Geral.Ator;
using Data.Interface.Geral.Prontuario;
using Data.Interface.Shared;
using Data.Repository.Geral;
using Data.Repository.Geral.Ator;
using Data.Repository.Geral.Prontuario;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.IdentityModel.Tokens;
using Service.Interface.Geral;
using Service.Interface.Geral.Ator;
using Service.Interface.Geral.Prontuario;
using Service.Services.Geral;
using Service.Services.Geral.Ator;
using Service.Services.Geral.Prontuario;

namespace ClinicaDentista.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddInjections(this IServiceCollection services)
        {
            services.AddScoped<IIbmrProvider, IbmrProvider>();
            services.TryAddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioService, UsuarioService>();

            services.AddTransient<IDocumentoRepository, DocumentoRepository>();
            services.AddTransient<IDocumentoService, DocumentoService>();

            services.AddTransient<IProntuarioRepository, ProntuarioRepository>();
            services.AddTransient<IProntuarioService, ProntuarioService>();

            services.AddTransient<IConsultaRepository, ConsultaRepository>();
            services.AddTransient<IConsultaService, ConsultaService>();

            services.AddTransient<IEnderecoRepository, EnderecoRepository>();
            services.AddTransient<IEnderecoService, EnderecoService>();

            services.AddTransient<IProdutoRepository, ProdutoRepository>();
            services.AddTransient<IProdutoService, ProdutoService>();

            services.AddTransient<IArmazemRepository, ArmazemRepository>();
            services.AddTransient<IArmazemService, ArmazemService>();

            services.AddTransient<IRecepcionistaRepository, RecepcionistaRepository>();
            services.AddTransient<IRecepcionistaService, RecepcionistaService>();

            services.AddTransient<IDentistaRepository, DentistaRepository>();
            services.AddTransient<IDentistaService, DentistaService>();

            services.AddTransient<IClienteRepository, ClienteRepository>();
            services.AddTransient<IClienteService, ClienteService>();
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
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
        }
    }
}
