using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Resources
{
    public class SpelerResource
    {
        public int Id { get; set; }
        public int GebruikerId { get; set; }
        public GebruikerResource Gebruiker { get; set; }
        public int RatingAanBeginVanWedstrijd { get; set; }
        public int PartijId { get; set; }

        public string KleurSpeler { get; set; }
    }
}
