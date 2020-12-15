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
    public class BerichtController : ControllerBase
    {
        private readonly IBerichtService _berichtService;
        private readonly IMapper _mapper;

        public BerichtController(IBerichtService berichtService, IMapper mapper)
        {
            this._berichtService = berichtService;
            this._mapper = mapper;
        }
        [HttpGet("bericht/GetAll")]
        public async Task<IEnumerable<Bericht>> AlleBerichten()
        {
            return await _berichtService.GetAllBerichten();
        }

        [HttpGet("bericht/Get/{id}")]
        public async Task<Bericht> GetBerichtById(int id)
        {
            return await _berichtService.GetBerichtById(id);
        }

        [HttpGet("bericht/GetFromChatId/{id}")]
        public async Task<IEnumerable<Bericht>> GetBerichtenFromChatByChatId(int id)
        {
            return await _berichtService.GetBerichtenFromChatByChatId(id);
        }
        [HttpPost("bericht/Post")]
        public async Task CreateBericht([FromBody] SaveBerichtResource newBericht)
        {
            var validator = new SaveBerichtResourceValidator();
            var result = await validator.ValidateAsync(newBericht);
            if (!result.IsValid)
            {
                throw new Exception(result.Errors.ToString());
            }
            var berichtToCreate = _mapper.Map<SaveBerichtResource, Bericht>(newBericht);
            await _berichtService.CreateBericht(berichtToCreate);
        }
        [HttpPut("bericht/Put")]
        public async Task UpdateBericht([FromBody] SaveBerichtResource bericht, int id)
        {
            var validator = new SaveBerichtResourceValidator();
            var result = await validator.ValidateAsync(bericht);
            if (id ==0 || !result.IsValid)
            {
                throw new Exception(result.Errors.ToString());
            }
            var BerichtToBeUpdated = await _berichtService.GetBerichtById(id);
            if(BerichtToBeUpdated == null)
            {
                throw new Exception("Bericht bestaat niet");
            }
            var _bericht = _mapper.Map<SaveBerichtResource, Bericht>(bericht);
            await _berichtService.UpdateBericht(BerichtToBeUpdated, _bericht);
        }
        [HttpDelete("bericht/Delete/{id}")]
        public async Task DeleteBericht(int id)
        {
            var _bericht = await _berichtService.GetBerichtById(id);
            await _berichtService.DeleteBericht(_bericht);
        }
    }
}
