using AutoMapper;
using Dobby.Api.Resources;
using Dobby.Core.Models;
using Dobby.Core.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Controllers
{
    [Route("[controller]")]
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
        [HttpGet("/zet/GetZetById/{id}")]
      public async Task<ActionResult<Zet>> GetZetWithId(int id)
        {
            var Zet = await _zetService.GetZetById(id);
            var _ZetResource = _mapper.Map<Zet, ZetResource>(Zet);
            return Ok(_ZetResource);
        }

    }
}
