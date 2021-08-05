using Locadora.Application.Dtos;
using Locadora.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Application.Handlers
{
    public class ListarUsuariosHandler
    {
        private readonly IUsuarioRepository _repositorioUsuario;

        public ListarUsuariosHandler(IUsuarioRepository repositorioUsuario)
        {        
            _repositorioUsuario = repositorioUsuario;    
        }

        public IEnumerable<UsuarioDto> Listar(UsuarioDto usuarioDto)
        {
            var usuarios = _repositorioUsuario.Listar(usuarioDto.Nome, usuarioDto.Documento, usuarioDto.Tipo, usuarioDto.Email, usuarioDto.Senha, usuarioDto.Telefone, usuarioDto.DDD, usuarioDto.Debito); 

            return usuarios.ToList()
                    .Select(usuario => new UsuarioDto
                    {
                        Id = usuario.Id,
                        Nome = usuario.Nome,
                        Documento = usuario.Documento,
                        Tipo = usuario.Tipo,
                        Email = usuario.Email,
                        Senha = usuario.Senha,
                        Telefone = usuario.Telefone,
                        DDD = usuario.DDD,
                        Debito = usuario.Debito
                    });
        }
    }
}