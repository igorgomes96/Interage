using InterageApp.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace InterageApp.Filters
{
    public class CustomIdentity : IIdentity
    {
        public CustomIdentity (UserAuth u, string AuthenticationType)
        {
            Name = u.CPF;
            this.AuthenticationType = AuthenticationType;
            IsAuthenticated = true;
            Usuario = u;
        }

        public string Name { get; set; }

        public string AuthenticationType { get; set; }

        public bool IsAuthenticated { get; set; }

        public UserAuth Usuario { get; set; }
    }
}