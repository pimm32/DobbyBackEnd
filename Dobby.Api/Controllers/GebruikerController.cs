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
    public class GebruikerController : ControllerBase
    {
        private readonly IGebruikerService _gebruikerService;
        private readonly IMapper _mapper;
        public GebruikerController(IGebruikerService gebruikerService, IMapper mapper)
        {
            this._gebruikerService = gebruikerService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<Gebruiker>> GetAllGebruikers()
        {
            return await _gebruikerService.GetAllGebruikers();
        }

        public async Task<IEnumerable<Gebruiker>> GetAllContactsFromGebruikerByGebruikerId(int gebruikerId)
        {
            return await _gebruikerService.GetAllContactsFromGebruikerByGebruikerId(gebruikerId);
        }

        public async Task<Gebruiker> GetGebruikerById(int id)
        {
            return await _gebruikerService.GetGebruikerById(id);
        }

        public async Task CreateGebruiker(Gebruiker gebruiker)
        {
            await _gebruikerService.CreateGebruiker(gebruiker);
        }

        public async Task UpdateGebruiker(Gebruiker gebruiker, int id)
        {

        }

        public async Task DeleteGebruiker(Gebruiker gebruiker)
        {
            await _gebruikerService.DeleteGebruiker(gebruiker);
        }
    }
}
