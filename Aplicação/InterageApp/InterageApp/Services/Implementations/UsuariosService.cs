using InterageApp.Models;
using InterageApp.Repository.Interfaces;
using InterageApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Claims;
using System.Security.Principal;
using InterageApp.DTO;

namespace InterageApp.Services.Implementations
{
    public class UsuariosService : IUsuariosService
    {

        private readonly IUsuariosRepository _usuarioRepository;
        private readonly ICredenciaisRepository _credenciaisRepository;

        public UsuariosService(IUsuariosRepository usuarioRepository, ICredenciaisRepository credenciaisRepository)
        {
            _usuarioRepository = usuarioRepository ?? throw new ArgumentNullException(nameof(usuarioRepository));
            _credenciaisRepository = credenciaisRepository ?? throw new ArgumentNullException(nameof(credenciaisRepository));
        }
        public UsuarioDTO Create(UsuarioDTO entidade)
        {
            _usuarioRepository.Create(entidade);
            return entidade;
        }

        public UsuarioDTO Create(UsuarioCredenciaisDTO user)
        {
            return _usuarioRepository.Create(user);
        }

        public UsuarioDTO Delete(string chave)
        {
            return _usuarioRepository.Delete(chave);
        }

        public void Delete(Func<UsuarioDTO, bool> predicate)
        {
            throw new NotSupportedException();
        }

        public ICollection<UsuarioDTO> Filter(Func<UsuarioDTO, bool> predicate)
        {
            throw new NotSupportedException();
        }

        public ClaimsIdentity GetClaimsIdentity(UsuarioDTO user)
        {
            user = Read(user.Email); //Necessário, para estar atualizado com o banco de dados
            
            if (user == null) return null;

            return new ClaimsIdentity(
                new GenericIdentity(user.Email, "Token"),
                new[]
                {
                    new Claim(user.Perfil.NomePerfil, user.Perfil.NomePerfil)
                });
        }

        public UsuarioDTO Read(string chave)
        {
            return _usuarioRepository.Read(chave);
        }

        public ICollection<UsuarioDTO> ReadAll()
        {
            return _usuarioRepository.ReadAll().ToList();
        }

        public UsuarioDTO Update(UsuarioDTO entidade)
        {
            return _usuarioRepository.Update(entidade);
        }

    }
}