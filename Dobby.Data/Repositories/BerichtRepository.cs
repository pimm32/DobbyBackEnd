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
    public class BerichtRepository: Repository<Bericht>, IBerichtRepository
    {
        public BerichtRepository(DobbyDbContext context)
            :base(context)
        {

        }
        public async Task<IEnumerable<Bericht>> GetAllBerichtenWithChatByChatId(int id)
        {
            return await DobbyDbContext.Berichten
                .Include(m=>m.Afzender)
                .Where(m => m.ChatId == id)
                .ToListAsync();
        }

        public async Task<Bericht> GetBerichtByBerichtId(int id)
        {
            return await DobbyDbContext.Berichten
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        //public async Task<IEnumerable<Bericht>> GetAllBerichtenSendByGebruikerByGebruikerId(int gebruikerId)
        //{
        //    return await DobbyDbContext.Berichten
        //        .Where(m => m.AfzenderId == gebruikerId)
        //        .ToListAsync();
        //}

        private DobbyDbContext DobbyDbContext
        {
            get { return Context as DobbyDbContext; }
        }

    }
}
