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
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;
        private readonly IMapper _mapper;
        public ContactController(IContactService contactService, IMapper mapper)
        {
            this._contactService = contactService;
            this._mapper = mapper;
        }
        [HttpGet("contact/GetAllContacts/{id}")]
        public async Task<IEnumerable<GebruikerContact>> GetAllContactsFromGebruikerByGebruikerId(int id)
        {
            return await _contactService.GetAllContactsFromGebruikerByGebruikerId(id);
        }
        [HttpPost("contact/Post")]
        public async Task CreateContact([FromBody] GebruikerContact contact)
        {
            await _contactService.CreateContact(contact);
        }
        
        [HttpDelete("contact/Delete/{id}")]
        public async Task DeleteContact(int id)
        {
            var _contact = await _contactService.GetContactById(id);
            await _contactService.DeleteContact(_contact);
        }
    }
}
