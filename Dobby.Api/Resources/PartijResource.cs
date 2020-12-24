using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Resources
{
    public class PartijResource
    {
        public int Id { get; set; }

        public ICollection<SpelerResource> Spelers { get; set; }
        public int SpeeltempoMinuten { get; set; }
        public int SpeeltempoFisherSeconden { get; set; }
        public int TijdWitSpeler { get; set; }
        public int TijdZwartSpeler { get; set; }
        //public ChatResource Chat { get; set; }
        public ICollection<ZetResource> Zetten { get; set; }
    }
}
