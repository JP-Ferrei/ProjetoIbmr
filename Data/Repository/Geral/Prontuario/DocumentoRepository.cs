using Data.Context;
using Data.Interface.Geral;
using Data.Interface.Geral.Prontuario;
using Data.Repository.Shared;
using Domain.Entities.Prontuario;

namespace Data.Repository.Geral.Prontuario
{
    public class DocumentoRepository: CrudRepository<Documento>, IDocumentoRepository
    {
        public DocumentoRepository(ClinicaContext context) : base(context)
        {
        }
    }
}
