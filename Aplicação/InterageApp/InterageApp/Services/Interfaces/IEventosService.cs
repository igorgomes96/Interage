using InterageApp.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InterageApp.Exceptions;

namespace InterageApp.Services.Interfaces
{
    public interface IEventosService
    {
        /// <summary>
        /// Lista todos os Eventos. 
        /// Se o usuário for promotor, lista os eventos promovidos por ele; se padrão, os eventos nos quais eles está inscrito.
        /// </summary>
        /// <returns></returns>
        ICollection<EventoDto> Listar(string emailUsuario);

        /// <summary>
        /// Busca um Evento pelo Id.
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Evento buscado</returns>
        EventoDto Buscar(int id);

        /// <summary>
        /// Somente usuário padrão. Cria um novo evento.
        /// </summary>
        /// <param name="evento"></param>
        /// <returns>Evento criado</returns>
        /// <exception cref="NaoInformadoException">Endereço não informado</exception>
        EventoDto CriarNovo(EventoDto evento);

        /// <summary>
        /// Exclui Evento.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        EventoDto ExcluirEvento(int id);


        /// <summary>
        /// Lista as atividade de um Evento.
        /// </summary>
        /// <param name="id">Id do Evento</param>
        /// <returns>Atividade do evento</returns>
        ICollection<AtividadeDto> Atividades(int id);
    }
}
