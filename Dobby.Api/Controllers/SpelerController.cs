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
    public class SpelerController : ControllerBase
    {
        private readonly ISpelerService _spelerService;
        private readonly IMapper _mapper;
        public SpelerController(ISpelerService spelerService, IMapper mapper)
        {
            this._spelerService = spelerService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<Speler>> GetAllSpelersWithPartijByPartijId(int partijId)
        {
            return await _spelerService.GetAllSpelersWithPartijByPartijId(partijId);
        }

        public async Task<Speler> GetSpelerById(int id)
        {
            return await _spelerService.GetSpelerById(id);
        }

        public async Task CreateSpeler(Speler newSpeler)
        {
            await _spelerService.CreateSpeler(newSpeler);
        }
        public async Task UpdateSpeler(Speler speler, int id)
        {

        }
        public async Task DeleteSpeler(Speler speler)
        {
            await _spelerService.DeleteSpeler(speler);
        }
    }
}
