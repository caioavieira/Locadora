using Locadora.Common.Enums;
using System;
using System.Collections.Generic;

namespace Locadora.Domain.Entidades
{
    public abstract class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public TipoUsuario Tipo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public string Telefone { get; set; }
        public int DDD { get; set; }
        public bool Debito { get; set; }
        public Endereco Endereco { get; set; }

        public Usuario()
        {            
        }

        public Usuario(Guid id, string nome, string documento, TipoUsuario tipo, string email, string senha, string telefone, int ddd, bool debito, Endereco endereco)
        {
            Id = id;
            Nome = nome;
            Documento = documento;
            Tipo = tipo;
            Email = email;
            Senha = senha;
            Telefone = telefone;
            DDD = ddd;
            Debito = debito;
            Endereco = endereco;
        }

        public bool DocumentoValido()
        {
            throw new NotImplementedException();
        }

        public bool TelefoneValido()
        {
            throw new NotImplementedException();
        }

        public bool EmailValido()
        {
            throw new NotImplementedException();
        }

        public Aluguel SolicitarAluguel(IEnumerable<Produto> produtos)
        {
            throw new NotImplementedException();
        }
    }
}