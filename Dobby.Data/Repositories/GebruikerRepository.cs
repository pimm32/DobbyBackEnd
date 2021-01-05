using Dobby.Core.Models;
using Dobby.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Data.Repositories
{
    public class GebruikerRepository: Repository<Gebruiker>, IGebruikerRepository
    {
        public GebruikerRepository(DobbyDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<GebruikerContact>> GetAllContactsOfGebruikerByGebruikerId(int gebruikerId)
        {
            return (IEnumerable<GebruikerContact>) await DobbyDbContext.GebruikerContacten
                .Include(m => m.Contact)
                .Where(m => m.GebruikerId == gebruikerId)
                .ToListAsync();
        }

        public async Task<Gebruiker> GetGebruikerByGebruikerId(int gebruikerId)
        {
            return await DobbyDbContext.Gebruikers
                .SingleOrDefaultAsync(m => m.Id == gebruikerId);
        }

        public async Task<IEnumerable<Gebruiker>> GetAllGebruikers()
        {
            return await DobbyDbContext.Gebruikers
                .ToListAsync();
        }



        private DobbyDbContext DobbyDbContext
        {
            get { return Context as DobbyDbContext; }
        }
    }
}
