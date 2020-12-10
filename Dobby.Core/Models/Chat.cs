using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Core.Models
{
    public class Chat
    {
        public int Id { get; set; }
        public ICollection<Bericht> Berichten { get; set; }
        public int PartijId { get; set; }
        public Partij Partij { get; set; }

    }
}
