using System;

namespace Domain.Entities.Ator
{
    public class Recepcionista: Usuario
    {
        public Recepcionista(string nome, string senha, bool ativo, string email, string telefone, DateTime dataNascimento) : base(nome, senha, ativo, email, telefone, dataNascimento)
        {
        }
    }
}
