using Domain.Entities;
using Domain.Entities.Ator;
using Domain.Entities.Prontuario;
using Microsoft.EntityFrameworkCore;

namespace Data.Context
{
    public class ClinicaContext: DbContext
    {
        public DbSet<Dentista> Dentistas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Documento> Documentos { get; set; }
        public DbSet<Prontuario> Prontuarios { get; set; }
        public DbSet<Consulta> Consultas { get; set; }
        public DbSet<Recepcionista> Recepcionistas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)=> 
            opt.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=ClinicaDentista;User Id=postgres;Password=DB@ccess;");
    }
}
