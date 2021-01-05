using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Repositories
{
    public interface IContactRepository: IRepository<GebruikerContact>
    {
        Task<IEnumerable<GebruikerContact>> GetAllContactsFromGebruikerByGebruikerId(int gebruikerId);
        Task<GebruikerContact> GetContactById(int id);

    }
}
