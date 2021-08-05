using Locadora.Common.Enums;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces;
using Locadora.Infrastructure.Contextos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Infrastructure.Repositorios
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly LocadoraContext _locadoraContext;

        public UsuarioRepository(LocadoraContext locadoraContext)
        {
            _locadoraContext = locadoraContext;
        }

        public Usuario Obter(Guid id)
        {
            return _locadoraContext.Usuarios.SingleOrDefault(s => s.Id == id);
        }

        public void Adicionar(Usuario usuario)
        {
            _locadoraContext.Usuarios.Add(usuario);
        }

        public void Atualizar(Usuario usuario)
        {
            _locadoraContext.Usuarios.Update(usuario);
        }

        public void Remover(Usuario usuario)
        {
            _locadoraContext.Usuarios.Remove(usuario);
        }

        public IQueryable<Usuario> Listar(string nome, string documento, TipoUsuario? tipo, string email, string senha, string telefone, int? ddd, bool? debito)
        {
            return _locadoraContext.Usuarios.Where(w => (string.IsNullOrWhiteSpace(nome) || w.Nome.ToLower().Contains(nome.ToLower())));
        }
        public IEnumerable<Usuario> ObterTodos()
        {
            return _locadoraContext.Usuarios.ToList();
        }

    }
}