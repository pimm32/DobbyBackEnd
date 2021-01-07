using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Resources
{
    public class ChatResource
    {
        public int Id { get; set; }
        public ICollection<BerichtResource> Berichten { get; set; }
        public int PartijId { get; set; }
    }
}
