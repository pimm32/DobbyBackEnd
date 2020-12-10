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
    public class SpelerRepository: Repository<Speler>, ISpelerRepository
    {
        public SpelerRepository(DobbyDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<Speler>> GetAllSpelersWithPartijByPartijId(int partijId)
        {
            return await DobbyDbContext.Spelers
                .Where(m=>m.Partij.Id == partijId)
                .ToListAsync();
        }

        public async Task<Speler> GetSpelerBySpelerId(int spelerId)
        {
            return await DobbyDbContext.Spelers
                .SingleOrDefaultAsync(m => m.Id == spelerId);
        }


        private DobbyDbContext DobbyDbContext
        {
            get { return Context as DobbyDbContext; }
        }
    }
}
