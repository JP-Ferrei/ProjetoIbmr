using System;
using System.Drawing;
using Domain.Interface.Shared;

namespace Domain.Entities
{
    public class Produto: IEntity
    {
        

        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Quantidade { get; set; }
        public DateTime Validade { get; set; }
        public string Descricao { get; set; }
        
        public Guid ArmazemId { get; set; }
        public Armazem? Armazem { get; set; }
        
        public DateTime DataDeAdicao { get; set; }

        public Produto()
        {
            DataDeAdicao = DateTime.Now;
        }
        public Produto(string nome, int quantidade, DateTime validade, string descricao, Guid armazemId)
        {
            Nome = nome;
            Quantidade = quantidade;
            Validade = validade;
            Descricao = descricao;
            ArmazemId = armazemId;
            DataDeAdicao = DateTime.Now;
        }
        
    }
}
