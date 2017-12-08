using InterageApp.Services.Interfaces;
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
        private readonly IGenericRepository<int, Endereco, EnderecoDto> _enderecoRepository;
        private readonly IInscricoesEventosRepository _inscricoesRepositoy;

        public EventosService(IGenericRepository<int, Evento, EventoDto> eventoRepository, 
            IGenericRepository<string, Usuario, UsuarioDto> usuarioRepository,
            IGenericRepository<int, Atividade, AtividadeDto> atividadeRepository,
            IGenericRepository<int, Endereco, EnderecoDto> enderecoRepository,
            IInscricoesEventosRepository inscricoesRepositoy)
        {
            _eventoRepository = eventoRepository;
            _usuarioRepository = usuarioRepository;
            _atividadeRepository = atividadeRepository;
            _enderecoRepository = enderecoRepository;
            _inscricoesRepositoy = inscricoesRepositoy;
        }

        public ICollection<AtividadeDto> Atividades(int id)
        {
            return _atividadeRepository.Query(x => x.CodEvento == id);
        }

        public EventoDto Buscar(int id)
        {
            return _eventoRepository.Find(id) ?? throw new NaoEncontradoException<Evento>();
        }

        public void CancelarInscricao(int id, string emailUsuario)
        {
            _inscricoesRepositoy.CancelarInscricao(id, emailUsuario);
        }

        public EventoDto CriarNovo(EventoDto evento)
        {
            UsuarioDto usuario = _usuarioRepository.Find(evento.EmailUsuarioPromotor);
            if (evento.FlagEnderecoPromotor)
                evento.CodEndereco = usuario.CodEndereco;
            else
            {
                if (evento.Endereco == null)
                    throw new NaoInformadoException("Endereço");
                else
                {
                    _enderecoRepository.Save(evento.Endereco);
                }
            }
            return _eventoRepository.Save(evento);
        }

        public EventoDto ExcluirEvento(int id)
        {
            foreach (AtividadeDto a in _atividadeRepository.Query(x => x.CodEvento == id))
            {
                _atividadeRepository.Delete(a.Codigo);
            }

            return _eventoRepository.Delete(id) ?? throw new NaoEncontradoException<Evento>();
        }

        public void InscreverParticipante(int id, string emailUsuario)
        {
            _inscricoesRepositoy.InscreverParticipante(id, emailUsuario);
        }

        public ICollection<EventoDto> Listar(string emailUsuario = null)
        {
            UsuarioDto usuario = _usuarioRepository.Find(emailUsuario);

            if (usuario == null)
                return _eventoRepository.List();

            if (usuario.Perfil.NomePerfil == "Promotor")
                return _eventoRepository.Query(x => x.EmailUsuarioPromotor == emailUsuario);
            else if (usuario.Perfil.NomePerfil == "Padrão")
                return _eventoRepository.Query(x => x.Participantes.Any(y => y.Email == emailUsuario));

            return _eventoRepository.List();

        }

        public bool VerificaInscricao(int id, string emailUsuario)
        {
            return _inscricoesRepositoy.VerificaInscricao(id, emailUsuario);
        }
    }
}