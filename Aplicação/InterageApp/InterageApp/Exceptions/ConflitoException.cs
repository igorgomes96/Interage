using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Exceptions
{
    public class ConflitoException<T>: Exception
    {
        public ConflitoException(string message): base(message) { }
        public ConflitoException() : base(typeof(T) + " já cadastrado!") { }
    }
}