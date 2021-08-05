using Locadora.Common.Enums;
using System;
using System.Collections.Generic;

namespace Locadora.Domain.Entidades
{
    public class Produto
    {
        public Guid Id { get; set; }
        public MidiaProduto Midia { get; set; }
        public string Titulo { get; set; }
        public CategoriaProduto Categoria { get; set; }
        public TipoProduto Tipo { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }

        public Produto()
        {            
        }

        public Produto(Guid id, MidiaProduto midia, string titulo, CategoriaProduto categoria, TipoProduto tipo, decimal valor, int quantidade)
        {
            Id = id;
            Midia = midia;
            Titulo = titulo;
            Categoria = categoria;
            Tipo = tipo;
            Valor = valor;
            Quantidade = quantidade;
        }

        public bool PermitidoAluguel()
        {
            return Quantidade > 0;
        }
    }
}
