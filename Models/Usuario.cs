﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ApiVentas.Models
{
    public class Usuario
    {
        [Key]
        public int id { get; set; }
        public string correo { get; set; }

        public string password { get; set; }
        public string username { get; set; }
        public bool estado { get; set; }
    }
}
