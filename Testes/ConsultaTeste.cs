using System;
using System.Threading.Tasks;
using Data.Context;
using Data.Interface.Geral;
using Data.Interface.Geral.Ator;
using Data.Repository.Geral;
using Data.Repository.Geral.Ator;
using Domain.Entities;
using Domain.Entities.Ator;
using Microsoft.EntityFrameworkCore;
using Service.Interface.Geral;
using Service.Interface.Geral.Ator;
using Service.Services.Geral;
using Service.Services.Geral.Ator;
using Xunit;

namespace Testes
{
    public class ConsultaTeste
    {
        private ClinicaContext _context;
        private IConsultaRepository _repo;
        private IConsultaService _serv;
        
        private IDentistaRepository _dentistaRepository;
        private IDentistaService _dentistaService;

        private IClienteRepository _clienteRepository;
        private IClienteService _clienteService;

        private IUsuarioRepository _usuarioRepository;
        private IUsuarioService _usuarioService;

        public ConsultaTeste()
        {
            var opt = new DbContextOptionsBuilder<ClinicaContext>().UseInMemoryDatabase("ClinicaTeste").Options;
            _context = new ClinicaContext(opt);
            
            _usuarioRepository = new UsuarioRepository(_context);
            _usuarioService = new UsuarioService(_usuarioRepository);

            _clienteRepository = new ClienteRepository(_context);
            _clienteService = new ClienteService(_clienteRepository, _usuarioService);
            
            _dentistaRepository = new DentistaRepository(_context);
            _dentistaService = new DentistaService(_dentistaRepository, _usuarioService);

            _repo = new ConsultaRepository(_context);
            _serv = new ConsultaService(_repo, _clienteService, _dentistaService);
        }

        [Fact]
        public async Task DeveCriarConsulta()
        {
            var cliente = new Cliente("joao", "123456",true,"teste@mail.com","3164588976",DateTime.Now);
            await _clienteService.Post(cliente);

            var dentista = new Dentista("pedro", "123456", true, "pedro@mail.com", "1234566789", DateTime.Now,
                "15616315");
            await _dentistaService.Post(dentista);

            var consulta = new Consulta(dentista.Id,cliente.Id,DateTime.Now);
            var consul = await _serv.Post(consulta);

            Assert.NotEmpty(await _serv.Get().ToListAsync());
        }
        
    }
}
