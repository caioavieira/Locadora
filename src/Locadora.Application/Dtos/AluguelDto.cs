using Locadora.Common.Enums;
using System;

namespace Locadora.Application.Dtos
{
    public class AluguelDto
    {
        public Guid Id { get; set; }
        public DateTime DataAluguel { get; set; }
        public DateTime DataEntrega { get; set; }
        public DateTime DataReserva { get; set; }
        public decimal Valor { get; set; }
        public StatusAluguel Status { get; set; }
        public int Prazo { get; set; }
        public UsuarioDto Usuario { get; set; }
        public ProdutoDto Produto { get; set; }
    }
}