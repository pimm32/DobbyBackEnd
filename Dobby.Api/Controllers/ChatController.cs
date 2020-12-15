using AutoMapper;
using Dobby.Core.Models;
using Dobby.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Controllers
{
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IChatService _chatService;
        private readonly IMapper _mapper;

        public ChatController(IChatService chatService, IMapper mapper )
        {
            this._chatService = chatService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<Chat>> GetAllChats()
        {
            return await _chatService.GetAllChats();
        }
        public async Task<IEnumerable<Chat>> GetAllChatsWithGebruikerByGebruikerId(int gebruikerId)
        {
            return await _chatService.GetAllChatsWithGebruikerByGebruikerId(gebruikerId);
        }

        public async Task<Chat> GetChatByChatId (int id)
        {
            return await _chatService.GetChatById(id);
        }

        public async Task<Chat> GetChatByPartijId(int partijId)
        {
            return await _chatService.GetChatByPartijId(partijId);
        }

        public async Task CreateChat(Chat newChat)
        {
            await _chatService.CreateChat(newChat);
        }

        public async Task UpdateChat(Chat chat, int id)
        {

        }

        public async Task DeleteChat(Chat chat)
        {
            await _chatService.DeleteChat(chat);
        }
    }
}
