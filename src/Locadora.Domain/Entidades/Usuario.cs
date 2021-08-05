using Locadora.Common.Enums;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            var rgxCpf = new Regex(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$");
            var rgxCnpj = new Regex(@"(^(\d{2}.\d{3}.\d{3}/\d{4}-\d{2})|(\d{14})$)");
            return rgxCpf.IsMatch(Documento) || rgxCnpj.IsMatch(Documento);
        }

        public bool TelefoneValido()
        {
            var rgx = new Regex(@"^(?:[2-8]|9[1-9])[0-9]{3}\-[0-9]{4}$");
            return rgx.IsMatch(Telefone);
        }

        public bool EmailValido()
        {
            var rgx = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
            return rgx.IsMatch(Email);
        }

        public Aluguel SolicitarAluguel(IEnumerable<Produto> produtos)
        {
            throw new NotImplementedException();
        }
    }
}