using Locadora.Application.Dtos;
using Locadora.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Application.Handlers
{
    public class ListarProdutosHandler
    {
        private readonly IProdutoRepository _repositorioProduto;

        public ListarProdutosHandler(IProdutoRepository repositorioProduto)
        {
            _repositorioProduto = repositorioProduto;
        }

        public IEnumerable<ProdutoDto> Listar(ProdutoDto produtoDto)
        {
            var produtos = _repositorioProduto.Listar(produtoDto.Midia, produtoDto.Titulo, produtoDto.Categoria, produtoDto.Tipo, produtoDto.Valor, produtoDto.Quantidade);
            
            return produtos.ToList()
                    .Select(produto => new ProdutoDto 
                                            {
                                                Id = produto.Id,
                                                Midia = produto.Midia,
                                                Titulo = produto.Titulo,
                                                Categoria = produto.Categoria,
                                                Tipo = produto.Tipo,
                                                Valor = produto.Valor,
                                                Quantidade = produto.Quantidade
                                            });
        }
    }
}