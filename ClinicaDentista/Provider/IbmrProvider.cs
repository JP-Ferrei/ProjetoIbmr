using System;
using System.Linq;
using System.Security.Claims;
using Data.Interface.Shared;
using Domain.Model;
using Microsoft.AspNetCore.Http;

namespace ClinicaDentista.Provider
{
    public class IbmrProvider : IIbmrProvider
    {
        
        private readonly IHttpContextAccessor _accessor;
        public SessionAppModel SessionApp { get; }

        public IbmrProvider(IHttpContextAccessor accessor)
        {
            _accessor = accessor;
            try
            {
                if (accessor.HttpContext == null)
                    return;

                var excecoes = new string[]{ 
                    "/v1/autenticador/usuario"
                };

                if (excecoes.Contains(accessor.HttpContext.Request.Path.ToString()))
                    return;

                if ("/v1/usuario" == accessor.HttpContext.Request.Path.ToString() && accessor.HttpContext.Request.Method == "POST")
                    return;

                var identity = accessor.HttpContext.User;

                SessionApp = new SessionAppModel(
                    Guid.Parse(identity.FindFirst(ClaimTypes.Upn).Value),
                    identity.FindFirst(ClaimTypes.Email).Value,
                    identity.FindFirst(ClaimTypes.Name).Value,
                    long.Parse(identity.FindFirst("tipoId").Value)
                    
                );
            }
            catch (Exception)
            {
                accessor.HttpContext.Response.StatusCode = 500;
                accessor.HttpContext.Response.WriteAsync("Erro em Ibmr Provider");

                throw new InvalidOperationException("Erro em Ibmr Provider");
            }
        }

        public string GetHost()
        {
            if (_accessor.HttpContext.Request.Headers.Any(x => x.Key == "HostManual"))
                return _accessor.HttpContext.Request.Headers["HostManual"][0].ToString();


            if (_accessor.HttpContext.Request.Headers.Any(x => x.Key == "Origin"))
                return new Uri(_accessor.HttpContext.Request.Headers["Origin"][0]).AbsoluteUri;

            return "localhost";
        }
    }
}
