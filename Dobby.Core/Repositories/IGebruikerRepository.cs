using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Repositories
{
    public interface IGebruikerRepository: IRepository<Gebruiker>
    {
        Task<IEnumerable<Gebruiker>> GetAllContactsOfGebruikerByGebruikerId(int gebruikerId);
        Task<Gebruiker> GetGebruikerByGebruikerId(int gebruikerId);
        Task<IEnumerable<Gebruiker>> GetAllGebruikers();

    }
}
