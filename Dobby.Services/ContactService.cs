using Dobby.Core.Models;
using Dobby.Core.Repositories;
using Dobby.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Services
{
    public class ContactService: IContactService
    {
        private readonly IContactRepository _contactRepository;
        public ContactService(IContactRepository contactRepository)
        {
            this._contactRepository = contactRepository;
        }
        public async Task<IEnumerable<GebruikerContact>> GetAllContactsFromGebruikerByGebruikerId(int gebruikerId)
        {
            return await _contactRepository.GetAllContactsFromGebruikerByGebruikerId(gebruikerId);
        }
        public async Task<GebruikerContact> GetContactById(int id)
        {
            return await _contactRepository.GetContactById(id);
        }
        public async Task CreateContact(GebruikerContact newContact)
        {
            await _contactRepository.AddAsync(newContact);
            await _contactRepository.CommitAsync();
        }
        public async Task DeleteContact(GebruikerContact contact)
        {
            _contactRepository.Remove(contact);
            await _contactRepository.CommitAsync();
        }
    }
}
