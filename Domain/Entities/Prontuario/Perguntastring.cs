using System;
using Domain.Interface.Shared;

namespace Domain.Entities.Prontuario
{
    public class Perguntastring: IEntity
    {
        public Guid Id { get; set; }
        public string Perunta { get; set; }
        public string? Reposta { get; set; }
        
        
    }
}
