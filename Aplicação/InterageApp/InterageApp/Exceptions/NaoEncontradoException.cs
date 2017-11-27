using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Exceptions
{
    public class NaoEncontradoException<T> : Exception
    {
        public NaoEncontradoException() : base(typeof(T) + " não encontrado!") { }
        public NaoEncontradoException(string message) : base(message) { }
    }
}