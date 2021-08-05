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
            return Status == StatusAluguel.ReservaConcluida;
        }

        public decimal CalcularValor()
        {
            var valor = 0M;

            foreach (var produto in Produtos)
            {
                var multa = 0M;

                if (PrazoExpirado()) {
                    if (produto.Tipo == TipoProduto.Jogo)
                        multa = produto.Valor;
                    else if (produto.Midia == MidiaProduto.BluRay)
                        multa = produto.Valor * 0.5M;
                    else if (produto.Midia == MidiaProduto.CD)
                        multa = produto.Valor * 0.3M;
                    else if (produto.Midia == MidiaProduto.DVD)
                        multa = produto.Valor * 0.4M;
                    else if (produto.Midia == MidiaProduto.VHS)
                        multa = produto.Valor * 0.2M;
                }

                valor += produto.Valor + multa;
            }

            Valor = valor;

            return Valor;
        }

        private bool PrazoExpirado()
        {
            return (DataReserva.Date - DataAluguel.Date).Days > 7;
        }
    }
}
