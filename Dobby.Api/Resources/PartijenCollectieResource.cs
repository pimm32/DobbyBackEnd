using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Resources
{
    public class PartijenCollectieResource
    {

        public ICollection<PartijResource> PartijenDieNogBezigZijn { get; set; }
        public ICollection<PartijResource> PartijenDieAfgelopenZijn { get; set; }
    }
}
