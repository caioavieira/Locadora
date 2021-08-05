using Locadora.Common.Enums;
using System;
using System.Collections.Generic;

namespace Locadora.Domain.Entidades
{
    public class Aluguel
    {
        public Guid Id { get; set; }
        public DateTime DataAluguel { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataReserva { get; set; }
        public decimal Valor { get; set; }
        public StatusAluguel Status { get; set; }
        public int Prazo { get; set; }
        public Usuario Usuario { get; set; }
        public IEnumerable<Produto> Produtos { get; set; }

        public Aluguel()
        {
            Produtos = new List<Produto>();
        }

        public Aluguel(Guid id, DateTime dataAluguel, DateTime dataEntrega, DateTime dataReserva, decimal valor, StatusAluguel status, int prazo, Usuario usuario, IEnumerable<Produto> produtos)
        {
            Id = id;
            DataAluguel = dataAluguel;
            DataEntrega = dataEntrega;
            DataReserva = dataReserva;
            Valor = valor;
            Status = status;
            Prazo = prazo;
            Usuario = usuario;
            Produtos = produtos;
        }

        public bool PrazoValido()
        {
            return Prazo >= 2;
        }

        public bool SolicitacaoConfirmada()
        {
            throw new NotImplementedException();
        }

        public bool PrazoExpirado()
        {
            throw new NotImplementedException();
        }

        public decimal CalcularValor()
        {
            throw new NotImplementedException();
        }
    }
}
