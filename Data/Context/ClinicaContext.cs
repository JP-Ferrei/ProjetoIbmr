using System;
using Data.Interface.Shared;
using Domain.Entities;
using Domain.Entities.Ator;
using Domain.Entities.Prontuario;
using Domain.Model;
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

        public SessionAppModel SessionApp { get; }

        
        protected override void OnConfiguring(DbContextOptionsBuilder opt) {
            opt.UseNpgsql("Host=localhost;Port=5432;Pooling=true;Database=ClinicaDentista;User Id=postgres;Password=DB@ccess;");
            
        }
        
        public ClinicaContext(DbContextOptions<ClinicaContext> opt, IIbmrProvider ibmrProvider) : base(opt)
        {
            SessionApp = ibmrProvider.SessionApp;
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            
            modelBuilder.Entity<Usuario>().HasData(new Usuario()
            {
                Id = Guid.Parse("baf6a601-e8a8-4ef0-9c24-054fffb6e905"),
                Nome = "Admin",
                Cpf = "111.111.111-12",
                Ativo = true,
                Email = "Admin@admin.com",
                Telefone = "12121231231",
                DataNascimento = DateTime.Now,
                Senha = "AQAAAAEAACcQAAAAEADhHTjZkX8cep+3TMGUDUM4yk8I+9S+2eu4WFKadW8X6iis4RqJ4Dw4Ob/fZUr3pQ==",
                TipoId = 4,
            });
            modelBuilder.Entity<Armazem>().HasData(new Armazem(){Id = Guid.Parse("8a312f2f-27b7-49de-980f-4e129faeccd6")});
            modelBuilder.Entity<TipoUsuario>().HasData(TipoUsuario.ObterDados());

            
            
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Email).IsUnique();
            modelBuilder.Entity<Usuario>().HasIndex(x => x.Cpf).IsUnique();
            modelBuilder.Entity<Dentista>().HasIndex(x => x.Cro).IsUnique();

            
            modelBuilder.Entity<Produto>().HasIndex(x => x.Nome).IsUnique();
            modelBuilder.Entity<Produto>().HasIndex(x => x.Id).IsUnique();
        }
    }
}
