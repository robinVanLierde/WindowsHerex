﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServiceAugustus.Models
{
    public class Leerling
    {
        
        public string Id { get; set; }
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public string opleiding { get; set; }
        public string campus { get; set; }

    }
}