using Dobby.Core.Models;
using Dobby.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Dobby.Data.Repositories
{
    public class PartijRepository: Repository<Partij>, IPartijRepository
    {
        public PartijRepository(DobbyDbContext context)
            :base(context)
        {

        }
        public async Task<IEnumerable<Partij>> GetAllWithZettenAsync()
        {
            return await DobbyDbContext.Partijen
                .Include(m => m.Zetten)
                .ToListAsync();
        }

        public async Task<Partij> GetWithZettenByIdAsync(int id)
        {
            return await DobbyDbContext.Partijen
                .Include(a => a.Zetten)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
        public async Task<IEnumerable<Partij>> GetAllByPlayerWithZettenAsync(int playerId)
        {
            return await DobbyDbContext.Partijen
                .Include(m => m.Zetten)
                .Where(m => m.Spelers.ElementAt(0).Gebruiker.Id == playerId || m.Spelers.ElementAt(1).Gebruiker.Id == playerId)
                .ToListAsync();
        }



        private DobbyDbContext DobbyDbContext
        {
            get { return Context as DobbyDbContext; }
        }

    }
}
