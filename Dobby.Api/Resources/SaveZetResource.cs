using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Resources
{
    public class SaveZetResource
    {
        public int BeginVeld { get; set; }
        public int EindVeld { get; set; }
        public int PartijId { get; set; }
        public string StandNaZet { get; set; }
    }
}
