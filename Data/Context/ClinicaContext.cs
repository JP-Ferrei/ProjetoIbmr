using Domain.Entities;
using Domain.Entities.Ator;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ClinicaContext: DbContext
    {
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public ClinicaContext(DbContextOptions<ClinicaContext> options) : base(options)
        {
           
        }

       
    }
}
