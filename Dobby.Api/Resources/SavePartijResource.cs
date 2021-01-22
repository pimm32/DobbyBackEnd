using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Resources
{
    public class SavePartijResource
    {
        public int SpeeltempoMinuten { get; set; }
        public int SpeeltempoFisherSeconden { get; set; }
        public int TijdWitSpeler { get; set; }
        public int TijdZwartSpeler { get; set; }
        public string Uitslag { get; set; }
    }
}
