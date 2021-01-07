using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Core.Models
{
    public class PartijenCollectie
    {
        public ICollection<Partij> PartijenDieNogBezigZijn { get; set; }
        public ICollection<Partij> PartijenDieAfgelopenZijn { get; set; }

        public PartijenCollectie(ICollection<Partij> af, ICollection<Partij> nietAf)
        {
            this.PartijenDieAfgelopenZijn = af;
            this.PartijenDieNogBezigZijn = nietAf;
        }

    }
}
