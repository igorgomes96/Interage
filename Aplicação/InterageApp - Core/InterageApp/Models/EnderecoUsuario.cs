using System;
using System.Collections.Generic;

namespace InterageApp.Models
{
    public partial class EnderecoUsuario
    {
        public string EmailUsuario { get; set; }
        public string Rua { get; set; }
        public string Complemento { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string UF { get; set; }
        public string CEP { get; set; }

        public Usuario Usuario { get; set; }
    }
}
