using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Dobby.Core.Models
{
    public class Partij
    {
        public int Id { get; set; }

        public ICollection<Speler> Spelers { get; set; }
        public int SpeeltempoMinuten { get; set; }
        public int SpeeltempoFisherSeconden { get; set; }
        public int TijdWitSpeler { get; set; }
        public int TijdZwartSpeler { get; set; }
        public string Uitslag { get; set; }
        public Chat Chat { get; set; }
        public ICollection<Zet> Zetten { get; set; }
    }
}
