﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CapaDatos;
using System.Data;
namespace CapaLogicaNegocio.Tables
{
    public class DaysTable
    {
        DayDatos dayDatos = new DayDatos();
        public DataTable tableDays()
        {
            return dayDatos.tableDays();
        }
    }
}
