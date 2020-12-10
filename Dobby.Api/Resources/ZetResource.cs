using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Resources
{
    public class ZetResource
    {
        public int Id { get; set; }
        public int BeginVeld { get; set; }
        public int EindVeld { get; set; }
        public PartijResource Partij { get; set; }
    }
}
