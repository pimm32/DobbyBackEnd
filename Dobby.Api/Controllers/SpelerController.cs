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
    public class SpelerController : ControllerBase
    {
        private readonly ISpelerService _spelerService;
        private readonly IMapper _mapper;
        public SpelerController(ISpelerService spelerService, IMapper mapper)
        {
            this._spelerService = spelerService;
            this._mapper = mapper;
        }
        [HttpGet("speler/GetAll/{id}")]
        public async Task<IEnumerable<Speler>> GetAllSpelersWithPartijByPartijId(int partijId)
        {
            return await _spelerService.GetAllSpelersWithPartijByPartijId(partijId);
        }
        [HttpGet("speler/Get/{id}")]
        public async Task<ActionResult<Speler>> GetSpelerById(int id)
        {
            var speler = await _spelerService.GetSpelerById(id); ;
            var _speler = _mapper.Map<Speler, SpelerResource>(speler);
            return Ok(_speler);
        }
        [HttpPost("speler/Post")]
        public async Task CreateSpeler(SaveSpelerResource newSpeler)
        {
            var validator = new SaveSpelerResourceValidator();
            var result = await validator.ValidateAsync(newSpeler);

            if (!result.IsValid)
            {
                throw new Exception(result.Errors.ToString());
            }
            var spelerToCreate = _mapper.Map<SaveSpelerResource, Speler>(newSpeler);
            await _spelerService.CreateSpeler(spelerToCreate);
        }
        [HttpPut("speler/Put/{id}")]
        public async Task UpdateSpeler(SaveSpelerResource speler, int id)
        {
            var validator = new SaveSpelerResourceValidator();
            var result = await validator.ValidateAsync(speler);

            if (id == 0 || !result.IsValid)
            {
                throw new Exception(result.Errors.ToString());
            }

            var spelerToBeUpdated = await _spelerService.GetSpelerById(id);

            if (spelerToBeUpdated == null)
            {
                throw new Exception("Speler bestaat niet");
            }

            var _speler = _mapper.Map<SaveSpelerResource, Speler>(speler);

            await _spelerService.UpdateSpeler(spelerToBeUpdated, _speler);
        }
        [HttpDelete("speler/Delete/{id}")]
        public async Task DeleteSpeler(int id)
        {
            var _speler = await _spelerService.GetSpelerById(id);
            await _spelerService.DeleteSpeler(_speler);
        }
    }
}
