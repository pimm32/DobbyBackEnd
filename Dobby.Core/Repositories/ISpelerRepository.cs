using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Repositories
{
    public interface ISpelerRepository: IRepository<Speler>
    {
        Task<IEnumerable<Speler>> GetAllSpelersWithPartijByPartijId(int partijId);
        Task<Speler> GetSpelerBySpelerId(int spelerId);
    }
}
