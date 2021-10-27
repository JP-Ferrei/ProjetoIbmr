using System.Threading.Tasks;
using Data.Context;
using Data.Interface.Geral;
using Data.Interface.Geral.Ator;
using Data.Repository.Shared;
using Domain.Entities.Ator;
using Microsoft.EntityFrameworkCore;

namespace Data.Repository.Geral.Ator
{
    public class UsuarioRepository:CrudRepository<Usuario>, IUsuarioRepository
    {
        public UsuarioRepository(ClinicaContext context) : base(context)
        {
        }
        
        
        public async Task<Usuario> Login(string email)
        {
            var usuario = await _context.Usuarios
                .IgnoreQueryFilters()
                .Include(x => x.Tipo)
                .SingleOrDefaultAsync(x => x.Email.ToUpper().Trim() == email.ToUpper().Trim());

            return usuario;
        }

        public async Task<Usuario> BuscarPorEmail(string email)
        {
            return await _query.FirstOrDefaultAsync(x => x.Email == email);
        }
    }
}
