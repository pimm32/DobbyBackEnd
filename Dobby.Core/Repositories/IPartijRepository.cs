﻿using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Repositories
{
    public interface IPartijRepository: IRepository<Partij>
    {
        Task<IEnumerable<Partij>> GetAllWithZettenAsync();
        Task<Partij> GetWithZettenByIdAsync(int id);

        Task<IEnumerable<Partij>> GetAllByPlayerWithZettenAsync(int playerId);
    }
}
