using System;
using System.Threading.Tasks;
using Data.Interface.Geral;
using Data.Repository.Geral;
using Domain.Entities;
using Framework.Exceptions;
using Framework.Helpers;
using Microsoft.VisualBasic.CompilerServices;
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

        public async Task AdicionarProduto(Guid armazemId,Guid produtoId)
        {
            var armazem = await _repository.GetByIdAsync(armazemId);
            var produto = await _produtoService.Get(produtoId);

            if (armazem == null || produto == null)
                throw new NotFoundException(MensagemHelper.RegistroNaoEncontrato);

            armazem.Produtos.Add(produto);

            await _repository.SaveChangesAsync();

        } 
    }
}
