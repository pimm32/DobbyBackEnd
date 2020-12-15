using AutoMapper;
using Dobby.Api.Resources;
using Dobby.Api.Validators;
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
        [HttpGet("chat/GetAll")]
        public async Task<IEnumerable<Chat>> GetAllChats()
        {
            return await _chatService.GetAllChats();
        }
        [HttpGet("chat/GetAllWithGebruiker")]
        public async Task<IEnumerable<Chat>> GetAllChatsWithGebruikerByGebruikerId(int gebruikerId)
        {
            return await _chatService.GetAllChatsWithGebruikerByGebruikerId(gebruikerId);
        }
        [HttpGet("chat/GetById")]
        public async Task<Chat> GetChatByChatId (int id)
        {
            return await _chatService.GetChatById(id);
        }
        [HttpGet("chat/GetByPartijId")]
        public async Task<Chat> GetChatByPartijId(int partijId)
        {
            return await _chatService.GetChatByPartijId(partijId);
        }
        [HttpPost("chat/Post")]
        public async Task CreateChat([FromBody] SaveChatResource newChat)
        {
            var validator = new SaveChatResourceValidator();
            var result = await validator.ValidateAsync(newChat);
            if (!result.IsValid)
            {
                throw new Exception(result.Errors.ToString());
            }
            var chatToCreate = _mapper.Map<SaveChatResource, Chat>(newChat);
            await _chatService.CreateChat(chatToCreate);
        }
        [HttpPut("chat/Put")]
        public async Task UpdateChat([FromBody] SaveChatResource chat, int id)
        {
            var validator = new SaveChatResourceValidator();
            var result = await validator.ValidateAsync(chat);
            if (id == 0 ||!result.IsValid)
            {
                throw new Exception(result.Errors.ToString());
            }
            var chatToBeUpdate = await _chatService.GetChatById(id);
            if(chatToBeUpdate == null)
            {
                throw new Exception("Chat bestaat niet");
            }
            var _chat = _mapper.Map<SaveChatResource, Chat>(chat);
            await _chatService.UpdateChat(chatToBeUpdate, _chat);
        }
        [HttpDelete("chat/Delete/{id}")]
        public async Task DeleteChat(int id)
        {
            var _chat = await _chatService.GetChatById(id);
            await _chatService.DeleteChat(_chat);
        }
    }
}
