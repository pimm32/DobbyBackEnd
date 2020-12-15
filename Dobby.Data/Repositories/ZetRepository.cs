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
    public class ZetRepository: Repository<Zet>, IZetRepository
    {

        public ZetRepository(DobbyDbContext context)
            :base(context)
        {

        }


        public async Task<Zet> GetWithPartijByIdAsync(int id)
        {
            return await DobbyDbContext.Zetten
                .Include(m => m.Partij)
                .SingleOrDefaultAsync(m => m.Id == id); 
        }


        public async Task<IEnumerable<Zet>> GetAllWithPartijByPartijIdAsync(int partijId)
        {
            return await DobbyDbContext.Zetten
                .Where(m => m.PartijId == partijId)
                .ToListAsync();
        }

        private DobbyDbContext DobbyDbContext
        {
            get { return Context as DobbyDbContext; }
        }

    }
}
