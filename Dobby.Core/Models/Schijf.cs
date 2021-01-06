using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Core.Models
{
    public class Schijf
    {
        public string Kleur { get; set; }

        public Schijf(string _kleur)
        {
            this.Kleur = _kleur;
        }
    }
}
