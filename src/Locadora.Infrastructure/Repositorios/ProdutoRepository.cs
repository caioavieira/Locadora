using Locadora.Common.Enums;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces;
using Locadora.Infrastructure.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Infrastructure.Repositorios
{
    public class ProdutoRepository : IProdutoRepository
    {
        private readonly LocadoraContext _locadoraContext;

        public ProdutoRepository(LocadoraContext locadoraContext)
        {
            _locadoraContext = locadoraContext;
        }

        public Produto Obter(int id)
        {
            return _locadoraContext.Produtos.SingleOrDefault(s => s.Id == id);
        }

        public void Adicionar(Produto produto)
        {
            _locadoraContext.Produtos.Add(produto);
        }

        public void Atualizar(Produto produto)
        {
            _locadoraContext.Produtos.Update(produto);
        }

        public void Remover(Produto produto)
        {
            _locadoraContext.Produtos.Remove(produto);
        }

        public IQueryable<Produto> Listar(MidiaProduto midia, string titulo, CategoriaProduto categoria, TipoProduto tipo, decimal valor, int quantidade)
        {
            return _locadoraContext.Produtos.Where(w => (string.IsNullOrWhiteSpace(titulo) || w.Titulo.ToLower().Contains(titulo.ToLower())));
        }
    }
}