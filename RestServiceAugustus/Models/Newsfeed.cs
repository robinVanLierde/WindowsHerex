using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RestServiceAugustus.Models
{
    public class Newsfeed
    {
        public int NewsfeedId { get; set; }
        public DateTimeOffset Date { get; set; }
        public string Opleiding { get; set; }
        public string Inhoud { get; set; }
        public string Title { get; set; }
    }
}