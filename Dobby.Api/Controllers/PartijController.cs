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
    public class PartijController : ControllerBase
    {
        private readonly IPartijService _partijService;
        private readonly IMapper _mapper;
        public PartijController(IPartijService partijService, IMapper mapper)
        {
            this._partijService = partijService;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<Partij>> GetAllPartijen()
        {
            return await _partijService.GetAllPartijen();
        }

        public async Task<IEnumerable<Partij>> GetAllPartijenFromGebruikerByGebruikerId(int gebruikerId)
        {
            return await _partijService.GetPartijenFromGebruikerByGebruikerId(gebruikerId);
        }

        public async Task<Partij> GetPartijById(int id)
        {
            return await _partijService.GetPartijById(id);
        }

        public async Task CreatePartij(Partij partij)
        {
            await _partijService.CreatePartij(partij);
        }
        public async Task UpdatePartij(Partij partij, int id)
        {

        }

        public async Task DeletePartij(Partij partij)
        {
            await _partijService.DeletePartij(partij);
        }
    }
}
