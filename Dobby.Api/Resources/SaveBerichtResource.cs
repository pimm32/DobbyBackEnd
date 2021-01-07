using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Resources
{
    public class SaveBerichtResource
    {
        public string Tekst { get; set; }
        public DateTime Datum { get; set; }
        public int AfzenderId { get; set; }
        public int ChatId { get; set; }
    }
}
