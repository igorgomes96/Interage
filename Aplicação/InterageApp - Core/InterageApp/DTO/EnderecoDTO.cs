using InterageApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class EnderecoDTO
    {

        public EnderecoDTO() { }
        public EnderecoDTO(EnderecoUsuario e)
        {
            if (e == null) return;
            Rua = e.Rua;
            Complemento = e.Complemento;
            Bairro = e.Bairro;
            Cidade = e.Cidade;
            UF = e.UF;
            CEP = e.CEP;
        }

        public EnderecoDTO(EnderecoAtividade e)
        {
            if (e == null) return;
            Rua = e.Rua;
            Complemento = e.Complemento;
            Bairro = e.Bairro;
            Cidade = e.Cidade;
            UF = e.UF;
            CEP = e.CEP;
        }

        public EnderecoAtividade GetEnderecoAtividade()
        {
            return new EnderecoAtividade
            {
                Rua = Rua,
                Complemento = Complemento,
                Bairro = Bairro,
                Cidade = Cidade,
                UF = UF,
                CEP = CEP
            };
        }

        public EnderecoUsuario GetEnderecoUsuario()
        {
            return new EnderecoUsuario
            {
                Rua = Rua,
                Complemento = Complemento,
                Bairro = Bairro,
                Cidade = Cidade,
                UF = UF,
                CEP = CEP
            };
        }


        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
    }
}