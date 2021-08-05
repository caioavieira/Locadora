using Locadora.Common.Enums;
using System;

namespace Locadora.Domain.Entidades
{
    public class Funcionario : Usuario
    {
        public Funcionario()
        {            
        }

        public Funcionario(Guid id, string nome, string documento, TipoUsuario tipo, string email, string senha, string telefone, int ddd, bool debito, Endereco endereco) 
            : base(id, nome, documento, tipo, email, senha, telefone, ddd, debito, endereco)
        {
        }

        public Aluguel RealizarBaixa(Aluguel aluguel)
        {
            if (!aluguel.SolicitacaoConfirmada())
                throw new Exception();

            aluguel.CalcularValor();
            aluguel.DataEntrega = DateTime.Today;
            aluguel.Status = StatusAluguel.BaixaLocacao;

            foreach (var produto in aluguel.Produtos)
            {
                produto.Quantidade++;
            }

            return aluguel;
        }
    }
}