using Locadora.Common.Enums;
using System;

namespace Locadora.Application.Dtos
{
    public class ProdutoDto
    {
        public int Id { get; set; }
        public MidiaProduto Midia { get; set; }
        public string Titulo { get; set; }
        public CategoriaProduto Categoria { get; set; }
        public TipoProduto Tipo { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
    }
}