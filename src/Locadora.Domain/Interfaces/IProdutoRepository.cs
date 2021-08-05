using Locadora.Common.Enums;
using Locadora.Domain.Entidades;
using System;
using System.Linq;

namespace Locadora.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        Produto Obter(int id);
        void Adicionar(Produto produto);
        void Atualizar(Produto produto);
        void Remover(Produto produto);
        IQueryable<Produto> Listar(MidiaProduto? midia, string titulo, CategoriaProduto? categoria, TipoProduto? tipo, decimal? valor, int? quantidade); 
    }
}