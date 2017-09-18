using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.Exceptions
{
    public class NaoEncontradoException : Exception
    {
        public string Resource { get; set; }
        public NaoEncontradoException(string resource)
        {
            Resource = resource;
        }
    }
}