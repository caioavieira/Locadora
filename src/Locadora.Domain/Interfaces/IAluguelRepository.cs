using Locadora.Common.Enums;
using Locadora.Domain.Entidades;
using System;
using System.Linq;

namespace Locadora.Domain.Interfaces
{
    public interface IAluguelRepository
    {
        Aluguel Obter(Guid id);
        void Adicionar(Aluguel aluguel);
        void Atualizar(Aluguel aluguel);
        void Remover(Aluguel aluguel);
        IQueryable<Aluguel> Listar(DateTime? dataAluguel, DateTime? dataEntrega, DateTime? dataReserva, decimal? valor, StatusAluguel? status, int? prazo); 
    }
}