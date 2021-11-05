using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Data.Context;
using Data.Interface.Geral.Ator;
using Data.Repository.Geral.Ator;
using Domain.Entities.Ator;
using Framework.Exceptions;
using Microsoft.EntityFrameworkCore;
using Service.Interface.Geral.Ator;
using Service.Services.Geral.Ator;
using Xunit;

namespace Testes
{
    public class UsuarioTeste
    {
        private IUsuarioService _service;
        private ClinicaContext _context;
        private IUsuarioRepository _repo;

        
        public UsuarioTeste()
        {
            var opt = new DbContextOptionsBuilder<ClinicaContext>().UseInMemoryDatabase("ClinicaTeste").Options;

            _context = new ClinicaContext(opt);
            _repo = new UsuarioRepository(_context);
            _service = new UsuarioService(_repo);
        }

        [Fact]
        public void DeveGerarToken()
        {
            var user = new Dentista("joao", "123456", true, "teste@mail.com", "(21)93239-2312", DateTime.Now, "2311")
            {
                Tipo = TipoUsuario.Dentista
            };

            var token = _service.GenerateToken(user, "3354103guo0607a910ibmr80", 480);

            var expected = typeof(string);
            Assert.IsType( expected , token);
        }

        [Fact]
        public async Task NaoDeveRetornarUsuario()
        {
            var user = new Usuario("joao", "123456", true, "teste@mail.com", "(21)93239-2312", DateTime.Now);
            await _service.Post(user);
            await Assert.ThrowsAsync<NotFoundException>( () => _service.BuscarPorEmail(user.Email));
        }
        
        [Fact]
        public async Task NaoDeveRetornarLogin()
        {
            var user = new Usuario("joao", "123456", true, "teste@mail.com", "(21)93239-2312", DateTime.Now);
            await _service.Post(user);
            await Assert.ThrowsAnyAsync<Exception>( () => _service.Login(user.Email,user.GetSenha(),"3354103guo0607a910ibmr80",480));
        }

     
        
    }
}
