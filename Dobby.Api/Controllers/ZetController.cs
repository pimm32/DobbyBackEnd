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
    public class ZetController : ControllerBase
    {
        private readonly IZetService _zetService;
        private readonly IMapper _mapper;

        public ZetController(IZetService zetService, IMapper mapper)
        {
            this._zetService = zetService;
            this._mapper = mapper;
        }

        //[HttpGet("zet/Get/{id}")]
        //public async Task<ActionResult<Zet>> GetZetById(int id)
        //{
        //    var Zet = await _zetService.GetZetById(id);
        //    var _ZetResource = _mapper.Map<Zet, ZetResource>(Zet);
        //    return Ok(_ZetResource);
        //}

        //[HttpGet("zet/GetByPartijId/{id}")]
        //public async Task<ActionResult<IEnumerable<Zet>>> GetZettenByPartijId (int id)
        //{
        //    var zetten = await _zetService.GetZettenByPartijId(id);
        //    var _zettenResource = _mapper.Map<IEnumerable<Zet>, IEnumerable<ZetResource>>(zetten);

        //    return Ok(_zettenResource);

        //}

        [HttpPost("zet/Post")]
        public async Task VoegZetToe([FromBody]SaveZetResource zet)
        {
            var validator = new SaveZetResourceValidator();
            var validationRes = await validator.ValidateAsync(zet);

            if (!validationRes.IsValid)
            {
                throw new Exception(validationRes.Errors.ToString());
            }

            var zetToCreate = _mapper.Map<SaveZetResource, Zet>(zet);
            
            await _zetService.CreateZet(zetToCreate);
        }

        [HttpPut("zet/Put/{id}")]
        public async Task UpdateZet([FromBody] SaveZetResource zet, int id)
        {
            var validator = new SaveZetResourceValidator();
            var result = await validator.ValidateAsync(zet);

            if (id == 0 || !result.IsValid)
            {
                throw new Exception(result.Errors.ToString());
            }

            var zetToBeUpdated = await _zetService.GetZetById(id);

            if(zetToBeUpdated == null)
            {
                throw new Exception("Zet bestaat niet");
            }

            var _zet = _mapper.Map<SaveZetResource, Zet>(zet);

            await _zetService.UpdateZet(zetToBeUpdated, _zet);

        }

        [HttpDelete("zet/Delete/{id}")]
        public async Task DeleteZet(int id)
        {
            var _zet = await _zetService.GetZetById(id);
            await _zetService.DeleteZet(_zet);
        }


    }
}
