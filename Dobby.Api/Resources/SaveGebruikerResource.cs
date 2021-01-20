using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Resources
{
    public class SaveGebruikerResource
    {
        public string Gebruikersnaam { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
    }
}
