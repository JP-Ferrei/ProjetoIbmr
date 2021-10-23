using System;
using Domain.Interface.Shared;

namespace Domain.Entities.Ator
{
    public class Usuario :IEntity
    {
        private string _senha;
        
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Cpf { get; set; }
        public DateTime DataCriacao { get; set; }
        public Boolean Ativo { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        
        public Guid? EnderecoId { get; set; }
        public Endereco? Endereco { get; set; }
        
        public DateTime DataNascimento { get; set; }
        
        public int? TipoId { get; set; }
        public TipoUsuario? Tipo { get; set; }
        
        public string Senha { get => _senha; set => _senha = value; }

        public Usuario()
        {
            DataCriacao = DateTime.Now;
        }


        public string GetSenha()
        {
            return _senha;
        }
       
    }
}
