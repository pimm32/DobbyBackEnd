using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Services
{
    public interface IZetService
    {
        Task<Zet> GetZetById(int id);
        Task<IEnumerable<Zet>> GetZettenByPartijId(int partijId);
        Task<Zet> CreateZet(Zet newZet);
        Task UpdateZet(Zet zetDieGeupdateMoetWorden, Zet zet);
        Task DeleteZet(Zet zet);
    }
}
