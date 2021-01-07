using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Core.Models
{
    public class Speler
    {
        public int Id { get; set; }
        public int GebruikerId { get; set; }
        public Gebruiker Gebruiker { get; set; }
        public int RatingAanBeginVanWedstrijd { get; set; }
        public int PartijId { get; set; }
        public Partij Partij { get; set; }

        public string KleurSpeler { get; set; }
    }
}
