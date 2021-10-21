using System;
using Domain.Entities.Ator;
using Domain.Interface.Shared;

namespace Domain.Entities
{
    public class Consulta: IEntity
    {
        public Guid Id { get; set; }
        public Guid DentistaId { get; set; }
        public Dentista Dentista { get; set; }
        public Guid ClienteId { get; set; }
        public Cliente Cliente { get; set; }
        public DateTime DataHora { get; set; }
        public DateTime DataCriacao { get; set; }
        public double Preco { get; set; }


        public Consulta()
        {
            DataCriacao = DateTime.Now;
        }
    }

    
}
