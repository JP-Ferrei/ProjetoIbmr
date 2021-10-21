using Data.Context;
using Data.Repository.Shared;
using Domain.Entities.Prontuario;

namespace ClinicaDentista.Controllers.Geral
{
    public class DocumentoRepository: CrudRepository<Documento>
    {
        public DocumentoRepository(ClinicaContext context) : base(context)
        {
        }
    }
}
