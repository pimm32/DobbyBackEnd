using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Services
{
    public interface ISpelerService
    {
        //Task<IEnumerable<Speler>> GetAllSpelersWithPartijByPartijId(int partijId);
        //Task<IEnumerable<Speler>> GetAllSpelersByGebruikerId(int gebruikerId);
        Task<Speler> GetSpelerById(int id);
        Task<Speler> CreateSpeler(Speler newSpeler);
        Task UpdateSpeler(Speler spelerDieGeupdateMoetWorden, Speler speler);
        Task DeleteSpeler(Speler speler);

    }
}
