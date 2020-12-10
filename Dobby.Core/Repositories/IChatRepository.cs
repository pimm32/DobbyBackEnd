using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Repositories
{
    public interface IChatRepository: IRepository<Chat>
    {
        Task<IEnumerable<Chat>> GetAllChatsWithGebruikerByGebruikerId(int gebruikerId);
        Task<Chat> GetChatByChatId(int id);
        Task<Chat> GetChatByPartijId(int partijId);
    }
}
