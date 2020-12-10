using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Repositories
{
    public interface IZetRepository: IRepository<Zet>
    {
        Task<Zet> GetWithPartijByIdAsync(int id);
        Task<IEnumerable<Zet>> GetAllWithPartijByPartijIdAsync(int partijId);
    }
}
