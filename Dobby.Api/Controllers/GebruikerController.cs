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
    public class GebruikerController : ControllerBase
    {
        private readonly IGebruikerService _gebruikerService;
        private readonly IMapper _mapper;
        public GebruikerController(IGebruikerService gebruikerService, IMapper mapper)
        {
            this._gebruikerService = gebruikerService;
            this._mapper = mapper;
        }
        [HttpGet("gebruiker/GetAll")]
        public async Task<IEnumerable<Gebruiker>> GetAllGebruikers()
        {
            return await _gebruikerService.GetAllGebruikers();
        }
        [HttpGet("gebruiker/Get/{id}")]
        public async Task<Gebruiker> GetGebruikerById(int id)
        {
            return await _gebruikerService.GetGebruikerById(id);
        }
        [HttpGet("gebruiker/GetByEmail/{email}")]
        public async Task<Gebruiker> GetGebruikerByEmail(string email)
        {
            return await _gebruikerService.GetGebruikerByEmail(email);
        }
        [HttpPost("gebruiker/Post")]
        public async Task CreateGebruiker([FromBody] SaveGebruikerResource gebruiker)
        {
            var validator = new SaveGebruikerResourceValidator();
            var validationRes = await validator.ValidateAsync(gebruiker);

            if (!validationRes.IsValid)
            {
                throw new Exception(validationRes.Errors.ToString());
            }

            var gebruikerToCreate = _mapper.Map<SaveGebruikerResource, Gebruiker>(gebruiker);

            await _gebruikerService.CreateGebruiker(gebruikerToCreate);
        }
        [HttpPut("gebruiker/Put")]
        public async Task UpdateGebruiker([FromBody] SaveGebruikerResource gebruiker, int id)
        {
            var validator = new SaveGebruikerResourceValidator();
            var validationRes = await validator.ValidateAsync(gebruiker);

            if (id == 0 || !validationRes.IsValid)
            {
                throw new Exception(validationRes.Errors.ToString());
            }

            var gebruikerToBeUpdate = await _gebruikerService.GetGebruikerById(id);
            if(gebruikerToBeUpdate == null)
            {
                throw new Exception("Gebruiker bestaat niet");
            }

            var _gebruiker = _mapper.Map<SaveGebruikerResource, Gebruiker>(gebruiker);
            await _gebruikerService.UpdateGebruiker(gebruikerToBeUpdate, _gebruiker);
        }
        [HttpDelete("gebruiker/Delete/{id}")]
        public async Task DeleteGebruiker(int id)
        {
            var _gebruiker = await _gebruikerService.GetGebruikerById(id);
            await _gebruikerService.DeleteGebruiker(_gebruiker);
        }
    }
}
