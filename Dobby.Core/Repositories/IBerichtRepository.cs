using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Repositories
{
    public interface IBerichtRepository: IRepository<Bericht>
    {
        Task<IEnumerable<Bericht>> GetAllBerichtenWithChatByChatId(int id);
        Task<Bericht> GetBerichtByBerichtId(int id);
        //Task<IEnumerable<Bericht>> GetAllBerichtenSendByGebruikerByGebruikerId(int gebruikerId);

    }
}
