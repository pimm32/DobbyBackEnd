using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Core.Models
{
    public class Bord
    {
        List<Veld> velden = new List<Veld>();
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
            return null;
        }

        public List<int> zwarteVeldenVanFEN(string FEN)
        {
            return null;
        }
    }
}
