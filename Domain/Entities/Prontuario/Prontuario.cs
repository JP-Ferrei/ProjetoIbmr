using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Interface.Shared;

namespace Domain.Entities.Prontuario
{
    public class Prontuario: IEntity
    {
        public Guid Id { get; set; }
        public ICollection<Perguntastring> PerguntasString { get; set; }
        public ICollection<PerguntaBooleana> PerguntaBooleanas { get; set; }
        public ICollection<Documento> Documentos { get; set; }
        

        public Prontuario()
        {
            PerguntasString = new List<Perguntastring>();
            PerguntaBooleanas = new List<PerguntaBooleana>();
            Documentos = new List<Documento>();
            
        }
    }
}
