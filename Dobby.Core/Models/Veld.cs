using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Core.Models
{
    public class Veld
    {
        public Schijf BezettendSchijf { get; set; }
        public int VeldNummer { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Veld(int x, int y)
        {
            this.VeldNummer = VeldnummerBerekenen(x, y);
            this.X = x;
            this.Y = y;
        }

        public int VeldnummerBerekenen(int x, int y)
        {
            if (y % 2 == 0 && x % 2 == 1)
            {
                return ((y-1) * 5 + (x + 1) / 2);
            }
            if (y % 2 == 1 && x % 2 == 0)
            {
                return ((y - 1) * 5 + (x / 2));
            }
            else
            {
                return -1;
            }
        }

        public void VeldBezettenMetSchijf(Schijf schijf)
        {
            this.BezettendSchijf = schijf;
        }
    }
}
