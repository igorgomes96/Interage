using InterageApp.Exceptions;
using InterageApp.Models;
using InterageApp.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace InterageApp.Repository.Implementations
{
    public class InscricoesEventosRepository : IInscricoesEventosRepository
    {
        private readonly DbContext _db;
        public InscricoesEventosRepository(DbContext db)
        {
            _db = db;
        }

        public void CancelarInscricao(int idEvento, string emailUsuario)
        {
            Evento evento = _db.Set<Evento>().Find(idEvento);
            if (evento == null)
                throw new NaoEncontradoException<Evento>();

            Usuario usuario = _db.Set<Usuario>().Find(emailUsuario);
            if (usuario == null)
                throw new NaoEncontradoException<Usuario>();

            if (!evento.Participantes.Contains(usuario))
                throw new NaoEncontradoException<object>("O usuário não está inscrito nesse evento!");

            evento.Participantes.Remove(usuario);
            _db.SaveChanges();
        }

        public void InscreverParticipante(int idEvento, string emailUsuario)
        {
            Evento evento = _db.Set<Evento>().Find(idEvento);
            if (evento == null)
                throw new NaoEncontradoException<Evento>();

            Usuario usuario = _db.Set<Usuario>().Find(emailUsuario);
            if (usuario == null)
                throw new NaoEncontradoException<Usuario>();

            if (evento.Participantes.Contains(usuario))
                throw new ConflitoException<object>("O usuário já está inscrito nesse evento!");

            evento.Participantes.Add(usuario);
            _db.SaveChanges();
        }

        public bool VerificaInscricao(int idEvento, string emailUsuario)
        {
            Usuario usuario = _db.Set<Usuario>().Find(emailUsuario);
            if (usuario == null)
                throw new NaoEncontradoException<Usuario>();

            return usuario.EventosInscritos.Count(x => x.Codigo == idEvento) > 0;
        }
    }
}