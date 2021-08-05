using Locadora.Common.Enums;
using System;

namespace Locadora.Application.Dtos
{
    public class UsuarioDto
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
        public EnderecoDto Endereco { get; set; }
    }
}