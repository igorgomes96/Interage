using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.DTO
{
    public class EnderecoDto
    {
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }
    }
}