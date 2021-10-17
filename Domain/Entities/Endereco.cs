using System;
using Domain.Interface.Shared;

namespace Domain.Entities
{
    public class Endereco: IEntity
    {
        public Guid Id { get; set; }
        public string Rua { get; set; }
        public string bairro { get; set; }
        public string Cidade { get; set; }
        public int Numero { get; set; }
    }
}
