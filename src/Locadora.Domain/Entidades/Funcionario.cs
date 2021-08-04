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

        public void RealizarBaixa(Aluguel aluguel)
        {
            throw new NotImplementedException();
        }
    }
}