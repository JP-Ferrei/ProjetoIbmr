using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Data.Interface.Geral;
using Domain.Entities;
using Framework.Exceptions;
using Framework.Helpers;
using Service.Interface.Geral;
using Service.Services.Shared;

namespace Service.Services.Geral
{
    public class ArmazemService: CrudService<Armazem, IArmazemRepository>, IArmazemService
    {
        private readonly IProdutoService _produtoService;
        
        public ArmazemService(IArmazemRepository repository, IProdutoService produtoService) : base(repository)
        {
            _produtoService = produtoService;
        }

        public async Task AdicionarProduto(Guid id ,Produto produto)
        {
            var armazem = await Get(id);

            if (armazem == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            if (ChecarSeJaExiste(armazem, produto))
                return;
                        
            var x = await _produtoService.Post(produto);
                
            armazem.Produtos.Add(x);

            await _repository.SaveChangesAsync();

        }

        private  bool ChecarSeJaExiste(Armazem armazem, Produto produto)
        {
            var item =  armazem.Produtos.FirstOrDefault(x => x.Nome.ToUpper().Trim() == produto.Nome.ToUpper().Trim());
            if (item != null)
            {
                item.Quantidade += produto.Quantidade;
                return true;
            }

            return false;
        }

        public async Task<List<Produto>> GetProdutos(Guid id)
        {
            var armazem =  await Get(id);
            if (armazem == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);
            return armazem.Produtos.ToList();
        }

        public async Task<Armazem> GetFirst()
        {
            var armazem = await _repository.GetFirst();

            if (armazem != null) return armazem;
            
            
            var arma = new Armazem();
            await Post(arma);
            await _repository.SaveChangesAsync();

            return armazem;
        }
    }
}
