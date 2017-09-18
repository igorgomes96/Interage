using Interage.DTO;
using Interage.Exceptions;
using Interage.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Web;

namespace Interage.Services
{
    public class UsuariosPadroesService
    {
        Contexto db = new Contexto();

        public IEnumerable<UsuarioPadraoDTO> Get()
        {
            return db.UsuarioPadrao.ToList()
                .Select(x => new UsuarioPadraoDTO(x));
        }

        public UsuarioPadraoDTO Get(int codUsuario, string cpf)
        {
            UsuarioPadrao user = db.UsuarioPadrao.Find(codUsuario, cpf);
            if (user == null) throw new NaoEncontradoException("Usuário Padrão");
            return new UsuarioPadraoDTO(user);
        }

        public UsuarioPadraoDTO Post(UsuarioPadraoDTO usuario)
        {
            db.Usuario.Add(usuario.GetUsuario());

            try
            {
                db.SaveChanges();
                db.UsuarioPadrao.Add(usuario.GetUsuarioPadrao());
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                throw new ConflitoException("Usuário Padrão");
            }
            catch (Exception e)
            {
                throw e;
            }

            return usuario;

        }

        public void Put(int codUsuario, string cpf, UsuarioPadraoDTO usuario)
        {
            if (codUsuario != usuario.CodUsuario || cpf != usuario.CPF)
                throw new ParametrosInvalidosException();

            db.Entry(usuario.GetUsuarioPadrao()).State = System.Data.Entity.EntityState.Modified;
            db.Entry(usuario.GetUsuario()).State = System.Data.Entity.EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioPadraoExists(usuario.GetUsuarioPadrao()))
                    throw new NaoEncontradoException("Usuário Padrão");
            }
            catch (Exception e)
            {
                throw e;
            }


        }

        public UsuarioPadraoDTO Delete(int codUsuario, string cpf)
        {
            UsuarioPadrao user = db.UsuarioPadrao.Find(codUsuario, cpf);

            if (user == null) throw new NaoEncontradoException("Usuário Padrão");

            UsuarioPadraoDTO u = new UsuarioPadraoDTO(user);

            db.Entry(user).State = System.Data.Entity.EntityState.Deleted;
            db.Entry(db.Usuario.Find(codUsuario)).State = System.Data.Entity.EntityState.Deleted;
            db.SaveChanges();

            return u;

        }

        private bool UsuarioPadraoExists(UsuarioPadrao user)
        {
            return db.UsuarioPadrao.Count(x => x.CodUsuario == user.CodUsuario && x.CPF == user.CPF) > 0;
        }
    }
}