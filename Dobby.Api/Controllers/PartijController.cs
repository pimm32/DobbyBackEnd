﻿using AutoMapper;
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
        private readonly IGebruikerService _gebruikerService;
        private readonly ISpelerService _spelerService;
        private readonly IMapper _mapper;
        public PartijController(IPartijService partijService, ISpelerService spelerService, IGebruikerService gebruikerService, IMapper mapper)
        {
            this._partijService = partijService;
            this._gebruikerService = gebruikerService;
            this._spelerService = spelerService;
            this._mapper = mapper;
        }
        [HttpGet("partij/GetAll")]
        public async Task<ActionResult<PartijenCollectie>> GetAllPartijen()
        {
            var result = await _partijService.GetAllPartijen();
            var _result = _mapper.Map<PartijenCollectie, PartijenCollectieResource>(result);
            return Ok(_result);
        }
        [HttpGet("partij/GetAll/{id}")]
        public async Task<ActionResult<PartijenCollectie>> GetAllPartijenFromGebruikerByGebruikerId(int id)
        {
            
            var result = await _partijService.GetPartijenFromGebruikerByGebruikerId(id);
            var _result = _mapper.Map<PartijenCollectie, PartijenCollectieResource>(result);
            return Ok(_result);
        }
        [HttpGet("partij/Get/{id}")]
        public async Task<ActionResult<Partij>> GetPartijById(int id)
        {
            var partij = await _partijService.GetPartijById(id);
            var _partij = _mapper.Map<Partij, PartijResource>(partij);
            return Ok(_partij);
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