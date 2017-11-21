using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Exceptions
{
    public class NotFoundException : Exception
    {
        public string Resource { get; set; }
        public NotFoundException(string resource) : base(resource + " não encontrado!") 
        {
            Resource = resource;
        }
    }
}