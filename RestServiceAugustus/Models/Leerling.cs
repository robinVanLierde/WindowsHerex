using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServiceAugustus.Models
{
    public class Leerling
    {
        
        public int LeerlingId { get; set; }
        public string Voornaam { get; set; }
        public string Naam { get; set; }
        public string Email { get; set; }
        public string Telefoon { get; set; }
        public string Opleiding { get; set; }
        public string Campus { get; set; }

    }
}