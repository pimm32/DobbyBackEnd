using Dobby.Core.Models;
using Dobby.Core.Repositories;
using Dobby.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Services
{
    public class ChatService: IChatService
    {
        private readonly IUnitOfWork _unitOfWork;

        public ChatService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        //public async Task<IEnumerable<Chat>> GetAllChats()
        //{
        //    return await _unitOfWork.Chats
        //        .GetAllAsync();
        //}
        //public async Task<IEnumerable<Chat>> GetAllChatsWithGebruikerByGebruikerId(int gebruikerId)
        //{
        //    return await _unitOfWork.Chats
        //        .GetAllChatsWithGebruikerByGebruikerId(gebruikerId);
        //}
        public async Task<Chat> GetChatById(int id)
        {
            return await _unitOfWork.Chats
                .GetChatByChatId(id);
        }
        //public async Task<Chat> GetChatByPartijId(int partijId)
        //{
        //    return await _unitOfWork.Chats
        //        .GetChatByPartijId(partijId);
        //}
        public async Task<Chat> CreateChat(Chat newChat)
        {
            await _unitOfWork.Chats.AddAsync(newChat);
            await _unitOfWork.CommitAsync();
            return newChat;
        }
        public async Task UpdateChat(Chat chatDieGeupdateMoetWorden, Chat chat)
        {
            chatDieGeupdateMoetWorden.Berichten = chat.Berichten;
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteChat(Chat chat)
        {
            _unitOfWork.Chats.Remove(chat);
            await _unitOfWork.CommitAsync();
        }

    }
}
