using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Resources
{
    public class GebruikerResource
    {
        public int Id { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
       
    }
}
