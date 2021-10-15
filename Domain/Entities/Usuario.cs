using System;
using Domain.Interface.Shared;

namespace Domain.Entities
{
    public class Usuario:IEntity
    {
        private string _senha;
        
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public string senha { get => null ; set => _senha = value; }
        public DateTime DataCriacao { get; set; }
        public Boolean Ativo { get; set; }
        public string Email { get; set; }
        public string telefone { get; set; }


        public Usuario()
        {
            DataCriacao = DateTime.Now;
        }
    }
}
