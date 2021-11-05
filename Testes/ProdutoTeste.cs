using System;
using System.Linq;
using System.Threading.Tasks;
using Data.Context;
using Data.Interface.Geral;
using Data.Repository.Geral;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Service.Interface.Geral;
using Service.Services.Geral;
using Xunit;

namespace Testes
{
    public class ProdutoTeste
    {
        private ClinicaContext _context;
        
        private IProdutoRepository _repository;
        private IArmazemRepository _repositoryArmazem;

        private IArmazemService _serviceArmazem;
        private IProdutoService _produtoService;

        
        
        public ProdutoTeste()
        {
            var opt = new DbContextOptionsBuilder<ClinicaContext>().UseInMemoryDatabase("ClinicaTeste").Options;

            _context = new ClinicaContext(opt);

            _repository = new ProdutoRepository(_context);
            _repositoryArmazem = new ArmazemRepository(_context);

            _serviceArmazem = new ArmazemService(_repositoryArmazem, _produtoService);
            _produtoService = new ProdutoService(_repository);
        }

        [Fact]
        public async Task DeveAdicionarProduto()
        {
            var armazem = new Armazem();
            await _serviceArmazem.Post(armazem);
            
            var produto = new Produto("luva", 3, DateTime.Now.AddDays(7), "...", armazem.Id);

            var p = await _produtoService.Post(produto);
            
            Assert.IsType<Produto>(p);
        }
        
        [Fact]
        public async Task DeveAdicionarQuantidadeNoProduto()
        {
            var armazem = new Armazem();
            await _serviceArmazem.Post(armazem);
            
            var produto = new Produto("luva", 3, DateTime.Now.AddDays(7), "...", armazem.Id);

            var p = await _produtoService.Post(produto);
            await _produtoService.Post(produto);
            await _produtoService.Post(produto);
            
            var prod = armazem.Produtos.First();
            var quant = prod.Quantidade;

            Assert.Equal( 12,quant);
        }
        
    }
}
