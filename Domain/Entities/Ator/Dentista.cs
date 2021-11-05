using System;

namespace Domain.Entities.Ator
{
    public class Dentista: Usuario
    {
        public string Cro { get; set; }

        public Dentista(string nome,string senha, bool ativo, string email, string telefone, DateTime dataNascimento, string cro) : base(nome, senha, ativo, email, telefone, dataNascimento)
        {
            Cro = cro;
        }
    }
}
