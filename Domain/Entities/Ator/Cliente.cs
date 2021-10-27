using System;

namespace Domain.Entities.Ator
{
    public class Cliente: Usuario 
    {
        //public Prontuario.Prontuario Prontuario { get; set; }
        public Guid? ResponsavelId { get; set; }
        
    }
}
