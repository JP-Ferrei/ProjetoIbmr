using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Interface.Geral.Ator;
using Data.Repository.Geral.Ator;
using Domain.Entities.Ator;
using Domain.Model;
using Microsoft.EntityFrameworkCore;
using Service.Interface.Geral.Ator;
using Service.Services.Geral.Ator;
using Xunit;

namespace Testes
{

    public class DentistaTeste
    {
        private ClinicaContext _context;
        private IDentistaRepository _repo;
        private IUsuarioRepository _userRepository;
        private IUsuarioService _userService;
        private IDentistaService _service;
        
        public DentistaTeste()
        {
            var opt = new DbContextOptionsBuilder().UseInMemoryDatabase("ClinicaTeste").Options;

            _context = new ClinicaContext(opt);

            _repo = new DentistaRepository(_context);
            _userRepository = new UsuarioRepository(_context);
            _userService = new UsuarioService(_userRepository);
            _service = new DentistaService(_repo,_userService);
        }
        
        [Fact]
        public async Task DeveAdicionarDentista()
        {
            var dentista = new Dentista("joao", "senha" ,true,"joao@mail.com","123123123",DateTime.Now,  "123123");

            await _service.Post(dentista);

            Assert.Equal(1,await _service.Get().CountAsync());
       }
        
        [Fact]
        public async Task DeveRetornarUsuario()
        {
            
            var dentista  = new Dentista("joao", "123456", true, "teste@mail.com", "(21)93239-2312", DateTime.Now,
                "12312"){Tipo = TipoUsuario.Dentista};
            
            await _service.Post(dentista);

            Assert.Equal(dentista , await _userService.BuscarPorEmail(dentista.Email));
        }
        
        [Fact]
        public async Task DeveRetornarLogin()
        {
            var dentista  = new Dentista("joao", "123456", true, "teste@mail.com", "(21)93239-2312", DateTime.Now,
                "12312"){Tipo = TipoUsuario.Dentista};
            
            await _service.Post(dentista);
            
            var assert = await _userService.Login("teste@mail.com", "123456", "3354103guo0607a910ibmr80", 480);

            Assert.IsType<RetornoLoginmodel>(assert);
        }

    }
    
}
