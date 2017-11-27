using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Exceptions
{
    public class NaoInformadoException : Exception
    {
        public string Campo { get; set; }

        public NaoInformadoException() : base() { }

        public NaoInformadoException(string campo) : base(campo + " não informado") { }
    }
}