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
    public class ContactRepository : Repository<GebruikerContact>, IContactRepository
    {
        public ContactRepository(DobbyDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<GebruikerContact>> GetAllContactsFromGebruikerByGebruikerId(int gebruikerId)
        {
            return (IEnumerable<GebruikerContact>)await DobbyDbContext.GebruikerContacten
                .Include(m => m.Contact)
                .Where(m => m.GebruikerId == gebruikerId)
                .ToListAsync();
        }
        public async Task<GebruikerContact> GetContactById(int id)
        {
            return await DobbyDbContext.GebruikerContacten
                   .SingleOrDefaultAsync(m => m.Id == id);

        }
        private DobbyDbContext DobbyDbContext
        {
            get { return Context as DobbyDbContext; }
        }

    }
}
