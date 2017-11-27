﻿using InterageApp.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using InterageApp.DTO;
using InterageApp.Repository.Interfaces;
using InterageApp.Models;
using InterageApp.Exceptions;

namespace InterageApp.Services.Implementations
{
    public class EventosService : IEventosService
    {
        private readonly IGenericRepository<int, Evento, EventoDto> _eventoRepository;
        private readonly IGenericRepository<string, Usuario, UsuarioDto> _usuarioRepository;
        private readonly IGenericRepository<int, Atividade, AtividadeDto> _atividadeRepository;

        public EventosService(IGenericRepository<int, Evento, EventoDto> eventoRepository, 
            IGenericRepository<string, Usuario, UsuarioDto> usuarioRepository,
            IGenericRepository<int, Atividade, AtividadeDto> atividadeRepository)
        {
            _eventoRepository = eventoRepository;
            _usuarioRepository = usuarioRepository;
            _atividadeRepository = atividadeRepository;
        }

        public ICollection<AtividadeDto> Atividades(int id)
        {
            return _atividadeRepository.Query(x => x.CodEvento == id);
        }

        public EventoDto Buscar(int id)
        {
            return _eventoRepository.Find(id) ?? throw new NaoEncontradoException<Evento>();
        }

        public EventoDto CriarNovo(EventoDto evento)
        {
            return _eventoRepository.Save(evento);
        }

        public EventoDto ExcluirEvento(int id)
        {
            return _eventoRepository.Delete(id) ?? throw new NaoEncontradoException<Evento>();
        }

        public ICollection<EventoDto> Listar(string emailUsuario)
        {
            UsuarioDto usuario = _usuarioRepository.Find(emailUsuario);
            if (usuario == null) throw new NaoEncontradoException<Usuario>();

            if (usuario.Perfil.NomePerfil == "Promotor")
                return _eventoRepository.Query(x => x.EmailUsuarioPromotor == emailUsuario);
            else
                return _eventoRepository.Query(x => x.Atividades.Any(y => y.Participantes.Any(z => z.Email == emailUsuario)));
        }
    }
}