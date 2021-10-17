using System;
using System.Buffers.Text;
using Domain.Interface.Shared;

namespace Domain.Entities.Prontuario
{
    public class Documento: IEntity
    {
        public Guid Id { get; set; }
        public string? Observacao { get; set; }
        public byte[] Imagens { get; set; }
    }
}
