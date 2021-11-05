using System;
using System.Threading.Tasks;
using Data.Context;
using Data.Interface.Geral;
using Data.Repository.Geral;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Interface.Geral;
using Service.Services.Geral;
using Xunit;
using Xunit.Abstractions;

namespace Testes
{
    public class ArmazemTeste
    {
        private ClinicaContext _context;
        
        private IArmazemRepository _repository;
        private IProdutoRepository _produtoRepository;
        
        private IProdutoService _produtoService;
        private IArmazemService _service;
        
        
        public ArmazemTeste()
        {
            var opt = new DbContextOptionsBuilder<ClinicaContext>().UseInMemoryDatabase("ClinicaTeste").Options;

            _context = new ClinicaContext(opt);
            
            _repository = new ArmazemRepository(_context);
            _produtoRepository = new ProdutoRepository(_context);
            
            _produtoService = new ProdutoService(_produtoRepository);
            _service = new ArmazemService(_repository, _produtoService);
            
        }

        [Fact]
        public async Task DeveReportarArmazem()
        {
            var arma = new Armazem();
            await _service.Post(arma);
            var armazem = await _service.GetFirst();
            
            Assert.IsType<Armazem>(armazem);
        }

        [Fact]
        public async Task DeveAdicionarProdutoNoArmazem()
        {
            var armazem = new Armazem();
            await _service.Post(armazem);

            var produto = new Produto("luva", 3, DateTime.Now.AddDays(7), "...", armazem.Id);

            await _service.AdicionarProduto(produto);
            Assert.NotEmpty(armazem.Produtos);

        }
    }
}
