using Locadora.Application.Dtos;
using Locadora.Application.Exceptions;
using Locadora.Common.Enums;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces;
using Locadora.Infrastructure.Contextos;
using Locadora.Infrastructure.Transacoes;
using System;
using System.Collections.Generic;
using System.Linq;

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
            if (aluguelDto.Usuario == null)
                throw new ArgumentException(nameof(aluguelDto.Usuario));

            if (aluguelDto.Produtos.Count() == 0)
                throw new ArgumentException(nameof(aluguelDto.Produtos));
            
            var usuario = _repositorioUsuario.Obter(aluguelDto.Usuario.Id);

            if (usuario == null)
                throw new ArgumentException(nameof(aluguelDto.Usuario));

            if (usuario.Debito)
                throw new UsuarioComDebitoPendenteException(usuario.Nome);
            
            var produtos = new List<Produto>();

            foreach (var produtoDto in aluguelDto.Produtos)
            {
                var produto = _repositorioProduto.Obter(produtoDto.Id);

                if (produto == null)
                    throw new ArgumentException(nameof(produtoDto));

                if (!produto.PermitidoAluguel())
                    throw new AluguelNaoPermitidoException(produto.Titulo);

                produtos.Add(produto);
            }

            var aluguel = new Aluguel(Guid.NewGuid(), DateTime.Now, aluguelDto.DataEntrega, aluguelDto.DataReserva, aluguelDto.Valor, StatusAluguel.SolicitacaoPendente, aluguelDto.Prazo, usuario, produtos);

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