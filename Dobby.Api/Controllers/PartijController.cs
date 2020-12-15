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
    public class PartijController : ControllerBase
    {
        private readonly IPartijService _partijService;
        private readonly IMapper _mapper;
        public PartijController(IPartijService partijService, IMapper mapper)
        {
            this._partijService = partijService;
            this._mapper = mapper;
        }
        [HttpGet("partij/GetAll")]
        public async Task<IEnumerable<Partij>> GetAllPartijen()
        {
            return await _partijService.GetAllPartijen();
        }
        [HttpGet("partij/GetAll/{id}")]
        public async Task<IEnumerable<Partij>> GetAllPartijenFromGebruikerByGebruikerId(int gebruikerId)
        {
            return await _partijService.GetPartijenFromGebruikerByGebruikerId(gebruikerId);
        }
        [HttpGet("partij/Get/{id}")]
        public async Task<Partij> GetPartijById(int id)
        {
            return await _partijService.GetPartijById(id);
        }
        [HttpPost("partij/Post")]
        public async Task CreatePartij(SavePartijResource partij)
        {
            var validator = new SavePartijResourceValidator();
            var result = await validator.ValidateAsync(partij);

            if (!result.IsValid)
            {
                throw new Exception(result.Errors.ToString());
            }
            var partijToCreate = _mapper.Map<SavePartijResource, Partij>(partij);
            await _partijService.CreatePartij(partijToCreate);
        }
        [HttpPut("partij/Put/{id}")]
        public async Task UpdatePartij(SavePartijResource partij, int id)
        {
            var validator = new SavePartijResourceValidator();
            var result = await validator.ValidateAsync(partij);

            if (id == 0 || !result.IsValid)
            {
                throw new Exception(result.Errors.ToString());
            }

            var partijToBeUpdated = await _partijService.GetPartijById(id);

            if (partijToBeUpdated == null)
            {
                throw new Exception("Zet bestaat niet");
            }

            var _partij = _mapper.Map<SavePartijResource, Partij>(partij);

            await _partijService.UpdatePartij(partijToBeUpdated, _partij);
        }
        [HttpDelete("partij/Delete/{id}")]
        public async Task DeletePartij(int id)
        {
            var _partij = await _partijService.GetPartijById(id);
            await _partijService.DeletePartij(_partij);
        }
    }
}
