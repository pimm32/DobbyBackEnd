namespace Dobby.Core.Repositories
{
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Threading.Tasks;
    using Dobby.Core.Models;

    public interface IGebruikerRepository : IRepository<Gebruiker>
    {
        Task<IEnumerable<GebruikerContact>> GetAllContactsOfGebruikerByGebruikerId(int gebruikerId);

        Task<Gebruiker> GetGebruikerByGebruikerId(int gebruikerId);

        Task<Gebruiker> GetGebruikerByEmail(string email);

        Task<IEnumerable<Gebruiker>> GetAllGebruikers();
    }
}
