﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Dobby.Core.Models
{
    public class Gebruiker
    {
        public int Id { get; set; }
        public string Gebruikersnaam { get; set; }
        public string Email { get; set; }
        public int Rating { get; set; }
        public ICollection<GebruikerContact> Contacten { get; set; }
        public ICollection<Speler> Spelers { get; set; }

    }
}
