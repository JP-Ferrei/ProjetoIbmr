using System;

namespace Domain.Model
{
    public class SessionAppModel
    {
        public Guid UsuarioId { get; }
        public string UsuarioNome { get; }
        public string Email { get; }
        public byte[] Foto { get; set; }
        public long TipoId { get; }
        
        public SessionAppModel(Guid usuarioId, string email, string usuarioNome, long tipoId)
        {
            UsuarioId = usuarioId;
            Email = email;
            UsuarioNome = usuarioNome;
            TipoId = tipoId;
        }
    }
}
