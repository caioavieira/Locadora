using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Locadora.Domain.Entidades
{
    public class Produto
    {
        public Guid Id { get; set; }
        public int Midia { get; set; }
        public string Titulo { get; set; }
        public int Categoria { get; set; }
        public decimal Valor { get; set; }
        public int Quantidade { get; set; }
        public Produto(Guid id, int midia, string titulo, int categoria, decimal valor, int quantidade)
        {
            Id = id;
            Midia = midia;
            Titulo = titulo;
            Categoria = categoria;
            Valor = valor;
            Quantidade = quantidade;
        }


    }
}
