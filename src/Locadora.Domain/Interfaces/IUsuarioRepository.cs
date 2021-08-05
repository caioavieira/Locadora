using Locadora.Common.Enums;
using Locadora.Domain.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        Usuario Obter(Guid id);
        void Adicionar(Usuario usuario);
        void Atualizar(Usuario usuario);
        void Remover(Usuario usuario);
        IEnumerable<Usuario> ObterTodos();
        IQueryable<Usuario> Listar(string nome, string documento, TipoUsuario? tipo, string email, string senha, string telefone, int? ddd, bool? debito, Endereco? endereco);        
    }
}