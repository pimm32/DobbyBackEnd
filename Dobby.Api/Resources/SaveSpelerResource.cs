using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Resources
{
    public class SaveSpelerResource
    {
        public int GebruikerId { get; set; }
        public int RatingAanBeginVanWedstrijd { get; set; }
        public int PartijId { get; set; }

        public string KleurSpeler { get; set; }
    }
}
