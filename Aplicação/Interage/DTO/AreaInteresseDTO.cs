using Interage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Interage.DTO
{
    public class AreaInteresseDTO
    {
        public AreaInteresseDTO (AreaInteresse a)
        {
            if (a == null) return;
            Codigo = a.Codigo;
            Interesse = a.Interesse;
        }
        public int Codigo { get; set; }
        public string Interesse { get; set; }
    }
}