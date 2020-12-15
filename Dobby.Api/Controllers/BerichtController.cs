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
    public class BerichtController : ControllerBase
    {
        private readonly IBerichtService _berichtService;
        private readonly IMapper _mapper;

        public BerichtController(IBerichtService berichtService, IMapper mapper)
        {
            this._berichtService = berichtService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<Bericht>> AlleBerichten()
        {
            return await _berichtService.GetAllBerichten();
        }

        public async Task<Bericht> GetBerichtById(int id)
        {
            return await _berichtService.GetBerichtById(id);
        }

        public async Task<IEnumerable<Bericht>> GetBerichtenFromChatByChatId(int chatId)
        {
            return await _berichtService.GetBerichtenFromChatByChatId(chatId);
        }

        public async Task CreateBericht(Bericht newBericht)
        {
            await _berichtService.CreateBericht(newBericht);
        }

        public async Task UpdateBericht(Bericht bericht, int id)
        {
            if (true)
            {
            }
        }

        public async Task DeleteBericht(Bericht bericht)
        {
            await _berichtService.DeleteBericht(bericht);
        }
    }
}
