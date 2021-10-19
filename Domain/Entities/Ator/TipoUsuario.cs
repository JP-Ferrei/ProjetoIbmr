using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Domain.Interface.Shared;

namespace Domain.Entities.Ator
{
    public class TipoUsuario
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        
        [StringLength(60), Required]
        public string Nome { get; set; }
        
        public string Role { get; set; }

        [NotMapped] public static TipoUsuario Admin => new TipoUsuario(1, "Administrativo", "Admin"); 
        [NotMapped] public static TipoUsuario Dentista => new TipoUsuario(2, "Dentista", "Dentista"); 
        [NotMapped] public static TipoUsuario Cliente => new TipoUsuario(3, "Cliente", "Cliente"); 
        [NotMapped] public static TipoUsuario Recepcionista => new TipoUsuario(4, "Recepcionista", "Recepcionista"); 
        
        public TipoUsuario(int id, string nome, string role)
        {
            Id = id;
            Nome = nome;
            Role = role;
        }

        public static TipoUsuario[] ObterDados()
        {
            return new TipoUsuario[]
            {
                Admin,
                Dentista,
                Cliente,
                Recepcionista
            };
        }
    }
}
