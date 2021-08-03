using System;

namespace Locadora.Domain.Entidades
{
    public class Aluguel
    {
        public Guid Id { get; set; }
        public DateTime DataAluguel { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataReserva { get; set; }
        public Decimal Valor { get; set; }
        public int Status { get; set; }
        public int prazo { get; set; }

        public Decimal CalcularValor()
        {
            return 1.5E6m;
        }

        public bool PrazoExpirado()
        {
            return true;
        }

        public bool SolicitacaoConfirmada()
        {
            return true;
        }
    }
}
