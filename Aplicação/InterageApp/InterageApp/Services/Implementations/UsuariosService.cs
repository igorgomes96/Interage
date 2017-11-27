using InterageApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterageApp.DTO;
using InterageApp.Models;
using InterageApp.Repository.Interfaces;
using InterageApp.Exceptions;

namespace InterageApp.Services.Implementations
{
    public class UsuariosService : IUsuariosService
    {
        private readonly IGenericRepository<string, Usuario, UsuarioDto> _usuarioRepository;
        private readonly IGenericRepository<string, Usuario, UsuarioCredenciaisDto> _usuarioCredenciaisRepository;
        private readonly IGenericRepository<int, Endereco, EnderecoDto> _enderecoRepository;

        public UsuariosService(IGenericRepository<string, Usuario, UsuarioDto> usuarioRepository,
            IGenericRepository<string, Usuario, UsuarioCredenciaisDto> usuarioCredenciaisRepository,
            IGenericRepository<int, Endereco, EnderecoDto> enderecoRepository)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioCredenciaisRepository = usuarioCredenciaisRepository;
            _enderecoRepository = enderecoRepository;
        }

        public UsuarioCredenciaisDto Cadastrar(UsuarioCredenciaisDto usuario)
        {
            try
            {
                EnderecoDto endereco = _enderecoRepository.Save(usuario.Endereco);
                usuario.CodEndereco = endereco.Codigo;
                return _usuarioCredenciaisRepository.Save(usuario);
            } catch (Exception e)
            {
                if (_usuarioRepository.Existe(usuario.Email))
                    throw new ConflitoException<Usuario>("O Email informado já foi cadastrado no Interage!");
                throw e;
            }
        }

        public UsuarioDto ExcluirCadastro(string emailUsuario)
        {
            try
            {
                return _usuarioRepository.Delete(emailUsuario);
            } catch (Exception e)
            {
                if (!_usuarioRepository.Existe(emailUsuario))
                    throw new NaoEncontradoException<Usuario>();
                throw e;
            }
        }
    }
}