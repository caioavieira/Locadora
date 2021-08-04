using Locadora.Application.Dtos;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces;
using Locadora.Infrastructure.Contextos;
using Locadora.Infrastructure.Transacoes;
using System;

namespace Locadora.Application.Handlers
{
    public class SolicitarAluguelHandler
    {
        private readonly LocadoraContext _locadoraContext;
        private readonly IAluguelRepository _repositorioAluguel;
        private readonly IProdutoRepository _repositorioProduto;
        private readonly IUsuarioRepository _repositorioUsuario;

        public SolicitarAluguelHandler(LocadoraContext locadoraContext, 
                                        IAluguelRepository repositorioAluguel,
                                        IProdutoRepository repositorioProduto,
                                        IUsuarioRepository repositorioUsuario)
        {
            _locadoraContext = locadoraContext;
            _repositorioAluguel = repositorioAluguel;
            _repositorioProduto = repositorioProduto;
            _repositorioUsuario = repositorioUsuario;
        }

        public Guid Solicitar(AluguelDto aluguelDto)
        {
            var usuario = _repositorioUsuario.Obter(aluguelDto.Usuario.Id);
            var produto = _repositorioProduto.Obter(aluguelDto.Produto.Id);
            var aluguel = new Aluguel(Guid.NewGuid(), aluguelDto.DataAluguel, aluguelDto.DataEntrega, aluguelDto.DataReserva, aluguelDto.Valor, aluguelDto.Status, aluguelDto.Prazo, usuario, produto);

            if (!aluguel.PrazoValido())
                throw new ArgumentException(nameof(aluguel.Prazo));

            using (var transacao = new Transacao(_locadoraContext))
            {    
                _repositorioAluguel.Adicionar(aluguel);            
                transacao.Commit();
            }

            return aluguel.Id;
        }
    }
}