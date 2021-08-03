using System;
using System.ComponentModel.DataAnnotations;

namespace Locadora.Domain.Entidades
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Documento { get; set; }
        public int Tipo { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public int Telefone { get; set; }
        public int DDD { get; set; }
        public Endereco Endereco { get; set; }
        // public Usuario(Guid id, string nome, string documento, int tipo, string email, string senha, int telefone, int ddd, Endereco endereco)
        // {
        //     Id = id;
        //     Nome = nome;
        //     Documento = documento;
        //     Tipo = tipo;
        //     Email = email;
        //     Senha = senha;
        //     Telefone = telefone;
        //     DDD = ddd;
        //     Endereco = endereco;
        // }
    }
}