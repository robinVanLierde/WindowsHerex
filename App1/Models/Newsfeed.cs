using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App1.Models
{
    public class Newsfeed
    {
        public Newsfeed()
        {

        }

        public DateTimeOffset Date { get; set; }
        public string Opleiding { get; set; }
        public string Inhoud { get; set; }
        public string Title { get; set; }
        public string Type { get; set; }
    }
}
