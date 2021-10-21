using System;
using Domain.Entities.Ator;

namespace Domain.Model
{
    public class LoginModel
    {

        public Guid UsuarioId { get; set; }
        public string UsuarioNome { get; set; }
        public string login { get; set; }
        public int TipoId { get; set; }
        public string Tipo { get; set; }
        
        public LoginModel(Guid usuarioId, string usuarioNome, string login, int tipoId, string tipo)
        {
            UsuarioId = usuarioId;
            UsuarioNome = usuarioNome;
            this.login = login;
            TipoId = tipoId;
            Tipo = tipo;
        }
        
    }
}
