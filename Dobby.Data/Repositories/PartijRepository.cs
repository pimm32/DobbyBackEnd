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
                .Include(m=>m.Spelers)
                .ToListAsync();
        }

        public async Task<Partij> GetWithZettenByIdAsync(int id)
        {
            return await DobbyDbContext.Partijen
                .Include(a => a.Zetten)
                .Include(m=>m.Spelers)
                .Include(m=>m.Chat)
                .SingleOrDefaultAsync(a => a.Id == id);
        }
        public async Task<IEnumerable<Partij>> GetAllByPlayerWithZettenAsync(int playerId)
        {
            return await DobbyDbContext.Partijen
                .Include(m => m.Zetten)
                .Where(m => m.Spelers.ElementAt(0).GebruikerId == playerId || m.Spelers.ElementAt(1).GebruikerId == playerId)
                .ToListAsync();

        }

        public async Task<int> CommitAsync()
        {
            return await DobbyDbContext.SaveChangesAsync();
        }

        private DobbyDbContext DobbyDbContext
        {
            get { return Context as DobbyDbContext; }
        }

    }
}
