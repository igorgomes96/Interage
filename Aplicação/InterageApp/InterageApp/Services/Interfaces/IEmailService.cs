﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterageApp.Services.Interfaces
{
    public interface IEmailService
    {
        void Send(object email);
    }
}
