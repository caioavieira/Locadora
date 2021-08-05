using Locadora.Application.Dtos;
using Locadora.Common.Enums;
using Locadora.Domain.Entidades;
using Locadora.Domain.Interfaces;
using Locadora.Infrastructure.Contextos;
using Locadora.Infrastructure.Transacoes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Locadora.Application.Handlers
{
    public class CadastrarUsuarioHandler
    {
        private readonly LocadoraContext _locadoraContext;
        private readonly IUsuarioRepository _repositorioUsuario;

        public CadastrarUsuarioHandler(LocadoraContext locadoraContext, IUsuarioRepository repositorioUsuario)
        {
            _locadoraContext = locadoraContext;
            _repositorioUsuario = repositorioUsuario;
        }

        public Guid Criar(UsuarioDto usuarioDto)
        {
            var usuario = null as Usuario;
            var endereco = new Endereco(Guid.NewGuid(), usuarioDto.Endereco.Logradouro, usuarioDto.Endereco.Bairro, usuarioDto.Endereco.Uf, usuarioDto.Endereco.Complemento, usuarioDto.Endereco.Cep, usuarioDto.Endereco.Numero, usuarioDto.Endereco.Cidade);

            if (usuarioDto.Tipo == TipoUsuario.Cliente)
                usuario = new Cliente(Guid.NewGuid(), 
                                        usuarioDto.Nome,
                                        usuarioDto.Documento,
                                        usuarioDto.Tipo,
                                        usuarioDto.Email,
                                        usuarioDto.Senha,
                                        usuarioDto.Telefone,
                                        usuarioDto.DDD,
                                        false,
                                        endereco);
            else if (usuario.Tipo == TipoUsuario.Funcionario)
                usuario = new Funcionario(Guid.NewGuid(), 
                                            usuarioDto.Nome,
                                            usuarioDto.Documento,
                                            usuarioDto.Tipo,
                                            usuarioDto.Email,
                                            usuarioDto.Senha,
                                            usuarioDto.Telefone,
                                            usuarioDto.DDD,
                                            false,
                                            endereco);
            // else
            //     throw new ArgumentException(nameof(usuario.Tipo));

            // if (!usuario.DocumentoValido())
            //    throw new ArgumentException(nameof(usuario.Documento));

            // if (!usuario.EmailValido())
            //    throw new ArgumentException(nameof(usuario.Email));

            // if (!usuario.TelefoneValido())
            //    throw new ArgumentException(nameof(usuario.Telefone));

            // if (!endereco.CepValido())
            //    throw new ArgumentException(nameof(endereco.Cep));

            using (var transacao = new Transacao(_locadoraContext))
            {    
                _repositorioUsuario.Adicionar(usuario);            
                transacao.Commit();
            }

            return usuario.Id;
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