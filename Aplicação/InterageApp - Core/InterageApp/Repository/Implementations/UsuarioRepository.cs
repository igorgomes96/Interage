using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using InterageApp.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InterageApp.Repository.Implementations
{
    public class UsuarioRepository : IUsuariosRepository
    {
        private readonly DbContext _db;
        private readonly IGenericMappingService<UsuarioDTO, Usuario> _usuarioMap;
        private readonly IEnderecoUsuarioMappingService _enderecoMap;
        private readonly IGenericMappingService<CredenciaisDTO, Credenciais> _credenciaisMap;

        public UsuarioRepository(DbContext db, 
            IGenericMappingService<UsuarioDTO, Usuario> usuarioMap, 
            IEnderecoUsuarioMappingService enderecoMap,
            IGenericMappingService<CredenciaisDTO, Credenciais> credenciaisMap)
        {
            _usuarioMap = usuarioMap;
            _enderecoMap = enderecoMap;
            _credenciaisMap = credenciaisMap;
            _db = db;
        }

        public UsuarioDTO Create(UsuarioCredenciaisDTO entidade)
        {
            UsuarioDTO usuarioDTO = new UsuarioDTO
            {
                Nome = entidade.Nome,
                CPF = entidade.CPF,
                Email = entidade.Email,
                Perfil = entidade.Perfil,
                EnderecoUsuario = entidade.EnderecoUsuario
            };

            _db.Set<Credenciais>().Add(_credenciaisMap.Map(entidade.Credenciais));
            _db.SaveChanges();
            Usuario usuario = _usuarioMap.Map(usuarioDTO);
            usuario = _db.Set<Usuario>().Add(usuario).Entity;
            _db.SaveChanges();
            _db.Set<EnderecoUsuario>().Add(_enderecoMap.Map(usuarioDTO));
            _db.SaveChanges();
            return _usuarioMap.Map(LoadReferences(usuario));
        }

        public UsuarioDTO Create(UsuarioDTO entidade)
        {
            throw new NotSupportedException();
        }

        public UsuarioDTO Delete(string chave)
        {
            Usuario usuario = LoadReferences(_db.Set<Usuario>().Find(chave));
            UsuarioDTO retorno = _usuarioMap.Map(usuario);

            if (usuario != null)
            {
                EnderecoUsuario endereco = _db.Set<EnderecoUsuario>().Find(chave);
                if (endereco != null)
                {
                    _db.Set<EnderecoUsuario>().Remove(endereco);
                    _db.SaveChanges();
                }

                usuario = _db.Set<Usuario>().Find(chave);  //Necessário, pois ao dar o commit acima o objeto está sendo desanexado do contexto
                if (usuario != null)
                {
                    _db.Set<Usuario>().Remove(usuario);
                    _db.SaveChanges();
                }

                Credenciais credenciais = _db.Set<Credenciais>().Find(chave);
                if (credenciais != null) { 
                    _db.Set<Credenciais>().Remove(credenciais);
                    _db.SaveChanges();
                }

            }
            
            return retorno;
        }

        public void Delete(Func<UsuarioDTO, bool> predicate)
        {
            throw new NotSupportedException();
        }

        public IQueryable<UsuarioDTO> Filter(Func<UsuarioDTO, bool> predicate)
        {
            throw new NotSupportedException();
        }

        public UsuarioDTO Read(string chave)
        {
            Usuario usuario = LoadReferences(_db.Set<Usuario>().Find(chave));
            return _usuarioMap.Map(usuario);
        }

        public IQueryable<UsuarioDTO> ReadAll()
        {
            return _db.Set<Usuario>()
                .Include(x => x.EnderecoUsuario)
                .Include(x => x.Perfil)
                .Select(x => _usuarioMap.Map(x));
        }

        public UsuarioDTO Update(UsuarioDTO entidade)
        {
            Usuario usuario = _usuarioMap.Map(entidade);
            EnderecoUsuario endereco = _enderecoMap.Map(entidade);

            #region Detaching objects
            Usuario usuarioLocal = _db.Set<Usuario>()
                .Local
                .FirstOrDefault(entry => entry.Email.Equals(usuario.Email));
            if (usuarioLocal != null)
                _db.Entry(usuarioLocal).State = EntityState.Detached;

            EnderecoUsuario enderecoLocal = _db.Set<EnderecoUsuario>()
                .Local
                .FirstOrDefault(entry => entry.EmailUsuario.Equals(usuario.Email));
            if (enderecoLocal != null)
                _db.Entry(enderecoLocal).State = EntityState.Detached;
            #endregion

            _db.Entry(endereco).State = EntityState.Modified;
            _db.Entry(usuario).State = EntityState.Modified;
            _db.SaveChanges();
            return entidade;
        }

        private Usuario LoadReferences(Usuario usuario)
        {
            if (usuario == null) return null;
            _db.Entry(usuario)
                .Reference(x => x.Perfil)
                .Load();

            _db.Entry(usuario)
                .Reference(x => x.EnderecoUsuario)
                .Load();

            return usuario;
        }
    }
}
