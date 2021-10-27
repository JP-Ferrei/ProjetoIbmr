using System;
using System.ComponentModel.DataAnnotations;
using Domain.Entities.Ator;
using Domain.Interface.Shared;

namespace Domain.Entities
{
    public class Consulta: IEntity
    {
        public Guid Id { get; set; }
        
        [Required]
        public Guid DentistaId { get; set; }
        public Dentista? Dentista { get; set; }
        
        [Required]
        public Guid ClienteId { get; set; }
        public Cliente? Cliente { get; set; }
        
        [Required]
        public DateTime DataHora { get; set; }
        public DateTime DataCriacao { get; set; }
        // public double Preco { get; set; }


        public Consulta()
        {
            DataCriacao = DateTime.Now;
        }
    }

    
}
