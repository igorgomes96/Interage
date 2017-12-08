using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Mapping.Implementations
{
    public class InteracaoMapper : ISingleMapper<Interacao, InteracaoDto>
    {
        public InteracaoDto Map(Interacao source)
        {
            return source == null ? null : new InteracaoDto
            {
                CodAtividade = source.CodAtividade,
                Mensagem = source.Mensagem,
                EmailUsuario = source.EmailUsuario,
                Hora = source.Hora
            };
        }

        public Interacao Map(InteracaoDto destination)
        {
            return destination == null ? null : new Interacao
            {
                CodAtividade = destination.CodAtividade,
                Mensagem = destination.Mensagem,
                EmailUsuario = destination.EmailUsuario,
                Hora = destination.Hora
            };
        }
    }
}