﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace InterageApp.Auth
{
    public class UserAuth
    {
        public string Email { get; set; }
        public string CPF { get; set; }
        public string NomePerfil { get; set; }
        public DateTime Validade { get; set; }
    }
}