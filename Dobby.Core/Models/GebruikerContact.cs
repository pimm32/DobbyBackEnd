using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Core.Models
{
    public class GebruikerContact
    {
        public int Id { get; set; }
        public int GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public int ContactId { get; set; }
        public Gebruiker Contact { get; set; }

    }
}
