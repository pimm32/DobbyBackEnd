using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Services
{
    public interface IGebruikerService
    {
        Task<IEnumerable<Gebruiker>> GetAllGebruikers();
        Task<IEnumerable<Gebruiker>> GetAllContactsFromGebruikerByGebruikerId(int gebruikerId);
        Task<Gebruiker> GetGebruikerById(int id);
        Task<Gebruiker> CreateGebruiker(Gebruiker newGebruiker);
        Task UpdateGebruiker(Gebruiker gebruikerDieGeupdateMoetWorden, Gebruiker gebruiker);
        Task DeleteGebruiker(Gebruiker gebruiker);
    }
}
