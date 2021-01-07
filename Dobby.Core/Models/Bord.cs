using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Core.Models
{
    public class Bord
    {
        public List<Veld> velden = new List<Veld>();
        public Bord(string Fen)
        {
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    velden.Add(new Veld(i, j));
                }
            }

            List<int> witteVelden = witteVeldenVanFEN(Fen);
            List<int> zwarteVelden = zwarteVeldenVanFEN(Fen);

            foreach (Veld veld in velden)
            {
                foreach (int veldnummers in witteVelden)
                {
                    if(veld.VeldNummer == veldnummers)
                    {
                        veld.VeldBezettenMetSchijf(new Schijf("Wit"));
                    }
                }
                foreach (int veldnummers in zwarteVelden)
                {
                    if(veld.VeldNummer == veldnummers)
                    {
                        veld.VeldBezettenMetSchijf(new Schijf("Zwart"));
                    }
                }
            }
        }

        public List<int> witteVeldenVanFEN(string FEN)
        {
            //W:W31,32,33,34,35,36,37,38,39,40,41,42,43,44,45,46,47,48,49,50:B1,2,3,4,5,6,7,8,9,10,11,12,13,14,15,16,17,18,19,20
            string witFen = FEN.Substring(3 , FEN.IndexOf("B") - 4);
            List<int> result = new List<int>();
            while (witFen.Length>0)
            {
                string nummer = witFen.Substring(1, witFen.IndexOf(",")-1);
                int _nummer = Int32.Parse(nummer);
                result.Add(_nummer);
                witFen = witFen.Substring(witFen.IndexOf(","));
            }
            return result;
        }

        public List<int> zwarteVeldenVanFEN(string FEN)
        {
            string zwartFen = FEN.Substring(FEN.IndexOf("B")+1);
            List<int> result = new List<int>();
            while (zwartFen.Length > 0)
            {
                string nummer = zwartFen.Substring(0, zwartFen.IndexOf(","));
                int _nummer = Int32.Parse(nummer);
                result.Add(_nummer);
                zwartFen = zwartFen.Substring(zwartFen.IndexOf(",") + 1);
            }
            return result;
        }
    }
}
