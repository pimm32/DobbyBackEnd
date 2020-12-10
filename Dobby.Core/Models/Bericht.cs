using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Core.Models
{
    public class Bericht
    {
        public int Id { get; set; }
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }
        public int AfzenderId { get; set; }
        public Gebruiker Afzender { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}
