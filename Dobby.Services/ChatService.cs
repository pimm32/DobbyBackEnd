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
        private readonly IChatRepository _chatRepository;

        public ChatService(IChatRepository chatRepository)
        {
            this._chatRepository = chatRepository;
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
            return await _chatRepository
                .GetChatByChatId(id);
        }
        //public async Task<Chat> GetChatByPartijId(int partijId)
        //{
        //    return await _unitOfWork.Chats
        //        .GetChatByPartijId(partijId);
        //}
        public async Task<Chat> CreateChat(Chat newChat)
        {
            await _chatRepository.AddAsync(newChat);
            await _chatRepository.CommitAsync();
            return newChat;
        }
        public async Task UpdateChat(Chat chatDieGeupdateMoetWorden, Chat chat)
        {
            chatDieGeupdateMoetWorden.Berichten = chat.Berichten;
            await _chatRepository.CommitAsync();
        }
        public async Task DeleteChat(Chat chat)
        {
            _chatRepository.Remove(chat);
            await _chatRepository.CommitAsync();
        }

    }
}
