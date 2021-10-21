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
        public DbSet<Armazem> Armazems { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder opt)=> 
            opt.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=ClinicaDentista;User Id=postgres;Password=DB@ccess;");

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TipoUsuario>().HasData(TipoUsuario.ObterDados());


            modelBuilder.Entity<Usuario>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Dentista>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Recepcionista>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Cliente>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Dentista>().HasIndex(x => x.Cro).IsUnique();
        }
    }
}
