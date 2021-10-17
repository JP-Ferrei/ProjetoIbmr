using System;
using Domain.Interface.Shared;

namespace Domain.Entities.Prontuario
{
    public class PerguntaBooleana: IEntity
    {
        public Guid Id { get; set; }
        public string Pergunta { get; set; }
        public bool Resposta { get; set; }
    }
}
