using Locadora.Common.Enums;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces;
using Locadora.Infrastructure.Contextos;
using System;
using System.Linq;

namespace Locadora.Infrastructure.Repositorios
{
    public class AluguelRepository : IAluguelRepository
    {
        private readonly LocadoraContext _locadoraContext;

        public AluguelRepository(LocadoraContext locadoraContext)
        {
            _locadoraContext = locadoraContext;
        }

        public Aluguel Obter(Guid id)
        {
            return _locadoraContext.Alugueis.SingleOrDefault(s => s.Id == id);
        }

        public void Adicionar(Aluguel aluguel)
        {
            _locadoraContext.Alugueis.Add(aluguel);
        }

        public void Atualizar(Aluguel aluguel)
        {
            _locadoraContext.Alugueis.Update(aluguel);
        }

        public void Remover(Aluguel aluguel)
        {
            _locadoraContext.Alugueis.Remove(aluguel);
        }

        public IQueryable<Aluguel> Listar(DateTime? dataAluguel, DateTime? dataEntrega, DateTime? dataReserva, decimal? valor, StatusAluguel? status, int? prazo)
        {
            return _locadoraContext.Alugueis.Where(w => (!dataAluguel.HasValue || w.DataAluguel.Date == dataAluguel.Value.Date));
        }
    }
}