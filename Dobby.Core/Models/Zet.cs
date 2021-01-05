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
        public string StandNaZet { get; set; }
        public int PartijId { get; set; }
        public Partij Partij { get; set; }

        public Zet(int begin, int eind, string FEN, int partij)
        {
            this.BeginVeld = begin;
            this.EindVeld = eind;
            this.StandNaZet = FEN;
            this.PartijId = partij;
        }

        public Zet(int id)
        {
            this.Id = id;
        }

        public Zet()
        {

        }
    }
}
