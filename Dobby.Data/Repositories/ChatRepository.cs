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
    public class ChatRepository: Repository<Chat>, IChatRepository
    {
        public ChatRepository(DobbyDbContext context)
            : base(context)
        {

        }

        public async Task<IEnumerable<Chat>> GetAllChatsWithGebruikerByGebruikerId(int gebruikerId)
        {
            return await DobbyDbContext.Chats
                .Where(m => m.Partij.Spelers.ElementAt(0).Gebruiker.Id == gebruikerId || m.Partij.Spelers.ElementAt(1).Gebruiker.Id == gebruikerId)
                .ToListAsync();
        }

        public async Task<Chat> GetChatByChatId(int id)
        {
            return await DobbyDbContext.Chats
                .SingleOrDefaultAsync(m => m.Id == id);
        }

        public async Task<Chat> GetChatByPartijId(int partijId)
        {
            return await DobbyDbContext.Chats
                .SingleOrDefaultAsync(m => m.PartijId == partijId);
        }


        private DobbyDbContext DobbyDbContext
        {
            get { return Context as DobbyDbContext; }
        }
    }
}
