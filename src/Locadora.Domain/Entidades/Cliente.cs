using Locadora.Common.Enums;
using System;

namespace Locadora.Domain.Entidades
{
    public class Cliente : Usuario
    {
        public Cliente()
        {
        }

        public Cliente(Guid id, string nome, string documento, TipoUsuario tipo, string email, string senha, string telefone, int ddd, bool debito, Endereco endereco) 
            : base(id, nome, documento, tipo, email, senha, telefone, ddd, debito, endereco)
        {
        }
    }
}