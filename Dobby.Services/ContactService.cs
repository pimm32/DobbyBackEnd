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
        private readonly IUnitOfWork _unitOfWork;
        public ContactService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<GebruikerContact>> GetAllContactsFromGebruikerByGebruikerId(int gebruikerId)
        {
            return await _unitOfWork.Contacts.GetAllContactsFromGebruikerByGebruikerId(gebruikerId);
        }
        public async Task<GebruikerContact> GetContactById(int id)
        {
            return await _unitOfWork.Contacts.GetContactById(id);
        }
        public async Task CreateContact(GebruikerContact newContact)
        {
            await _unitOfWork.Contacts.AddAsync(newContact);
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteContact(GebruikerContact contact)
        {
            _unitOfWork.Contacts.Remove(contact);
            await _unitOfWork.CommitAsync();
        }
    }
}
