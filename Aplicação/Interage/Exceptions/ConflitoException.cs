using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.Exceptions
{
    public class ConflitoException : Exception
    {
        public string Resource { get; set; }
        public ConflitoException(string resource)
        {
            Resource = resource;
        }
    }
}