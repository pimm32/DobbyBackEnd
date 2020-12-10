using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Core.Models
{
    public class Zet
    {
        public int Id { get; set; }
        public int BeginVeld { get; set; }
        public int EindVeld { get; set; }
        public int PartijId { get; set; }
        public Partij Partij { get; set; }

    }
}
