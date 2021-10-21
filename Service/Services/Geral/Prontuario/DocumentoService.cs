using Data.Interface.Geral.Prontuario;
using Data.Repository.Geral.Prontuario;
using Domain.Entities.Prontuario;
using Service.Interface.Geral.Prontuario;
using Service.Services.Shared;

namespace Service.Services.Geral.Prontuario
{
    public class DocumentoService: CrudService<Documento, IDocumentoRepository>, IDocumentoService
    {
        public DocumentoService(IDocumentoRepository repository) : base(repository)
        {
        }
    }
}
