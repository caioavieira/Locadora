using Locadora.Application.Dtos;
using Locadora.Common.Enums;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces;
using Locadora.Infrastructure.Contextos;
using Locadora.Infrastructure.Transacoes;
using System;

namespace Locadora.Application.Handlers
{
    public class CadastrarProdutoHandler
    {
        private readonly LocadoraContext _locadoraContext;
        private readonly IProdutoRepository _repositorioProduto;

        public CadastrarProdutoHandler(LocadoraContext locadoraContext, IProdutoRepository repositorioProduto)
        {
            _locadoraContext = locadoraContext;
            _repositorioProduto = repositorioProduto;
        }

        public Guid Criar(ProdutoDto produtoDto)
        {
            var produto = new Produto(Guid.NewGuid(), produtoDto.Midia, produtoDto.Titulo,produtoDto.Categoria,
            produtoDto.Tipo, produtoDto.Valor, produtoDto.Quantidade);
   
                      
            using (var transacao = new Transacao(_locadoraContext))
            {    
                _repositorioProduto.Adicionar(produto);            
                transacao.Commit();
            }

            return produto.Id;
        }
    }
}