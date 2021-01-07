using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Services
{
    public interface IContactService
    {
        Task<IEnumerable<GebruikerContact>> GetAllContactsFromGebruikerByGebruikerId(int gebruikerId);
        Task<GebruikerContact> GetContactById(int id);
        Task CreateContact(GebruikerContact newContact);
        Task DeleteContact(GebruikerContact contact);

    }
}
