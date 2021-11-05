using System;

namespace Domain.Entities.Ator
{
    public class Cliente: Usuario 
    {
        //public Prontuario.Prontuario Prontuario { get; set; }
        public Guid? ResponsavelId { get; set; }

        public Cliente(string nome, string senha, bool ativo, string email, string telefone, DateTime dataNascimento) : base(nome, senha, ativo, email, telefone, dataNascimento)
        {
        }
    }
}
