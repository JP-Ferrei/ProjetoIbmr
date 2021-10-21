using System;
using System.Collections;
using System.Collections.Generic;
using Domain.Interface.Shared;

namespace Domain.Entities
{
    public class Armazem:IEntity
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; }
        public Guid EnderecoId { get; set; }
        public Endereco Endereco { get; set; }
        public ICollection<Produto> Produtos { get; set; }


        public Armazem()
        {
            Produtos = new List<Produto>();
        }
        
    }
}
