using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Services
{
    public interface IChatService
    {
        //Task<IEnumerable<Chat>> GetAllChats();
        //Task<IEnumerable<Chat>> GetAllChatsWithGebruikerByGebruikerId(int gebruikerId);
        Task<Chat> GetChatById(int id);
        //Task<Chat> GetChatByPartijId(int partijId);
        Task<Chat> CreateChat(Chat newChat);
        Task UpdateChat(Chat chatDieGeupdateMoetWorden, Chat chat);
        Task DeleteChat(Chat chat);

    }
}
