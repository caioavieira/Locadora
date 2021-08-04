using System;

namespace Locadora.Domain.Entidades
{
    public class Aluguel
    {
        public Guid Id { get; set; }
        public DateTime DataAluguel { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataReserva { get; set; }
        public decimal Valor { get; set; }
        public int Status { get; set; }
        public int Prazo { get; set; }
        public Usuario Usuario { get; set; }
        public Produto Produto { get; set; }

        public Aluguel(Guid id, DateTime dataAluguel, DateTime dataEntrega, DateTime dataReserva, decimal valor, int status, int prazo, Usuario usuario, Produto produto)
        {
            Id = id;
            DataAluguel = dataAluguel;
            DataEntrega = dataEntrega;
            DataReserva = dataReserva;
            Valor = valor;
            Status = status;
            Prazo = prazo;
            Usuario = usuario;
            Produto = produto;
        }

        public Decimal CalcularValor()
        {
            throw new NotImplementedException();
        }

        public bool PrazoExpirado()
        {
            throw new NotImplementedException();
        }

        public bool SolicitacaoConfirmada()
        {
            throw new NotImplementedException();
        }
    }
}
