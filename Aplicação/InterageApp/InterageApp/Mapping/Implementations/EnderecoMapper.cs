using InterageApp.DTO;
using InterageApp.Mapping.Interfaces;
using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Mapping.Implementations
{
    public class EnderecoMapper : ISingleMapper<Endereco, EnderecoDto>
    {
        public EnderecoDto Map(Endereco source)
        {
            return source == null ? null : new EnderecoDto
            {
                Codigo = source.Codigo,
                Rua = source.Rua,
                Complemento = source.Complemento,
                Bairro = source.Bairro,
                Cidade = source.Cidade,
                UF = source.UF,
                CEP  = source.CEP,
                Numero = source.Numero
            };
        }

        public Endereco Map(EnderecoDto destination)
        {
            return destination == null ? null :new Endereco
            {
                Codigo = destination.Codigo,
                Rua = destination.Rua,
                Complemento = destination.Complemento,
                Bairro = destination.Bairro,
                Cidade = destination.Cidade,
                UF = destination.UF,
                CEP = destination.CEP,
                Numero = destination.Numero
            };
        }
    }
}