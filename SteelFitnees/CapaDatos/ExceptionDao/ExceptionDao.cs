﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.ExceptionDao
{
    public class ExceptionDao : Exception
    {
        private string message;
        public ExceptionDao(string message)
        {
            this.message = message;
        }
        public string getMessage()
        {
            return message;
        }
    }
}
