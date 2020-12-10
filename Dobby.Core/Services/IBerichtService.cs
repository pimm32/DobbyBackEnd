using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Services
{
    public interface IBerichtService
    {
        Task<IEnumerable<Bericht>> GetAllBerichten();
        Task<Bericht> GetBerichtById(int id);
        Task<IEnumerable<Bericht>> GetBerichtenFromChatByChatId(int chatId);
        Task<Bericht> CreateBericht(Bericht newBericht);
        Task UpdateBericht(Bericht berichtDieGeupdateMoetWorden, Bericht bericht);
        Task DeleteBericht(Bericht bericht);
    }
}
