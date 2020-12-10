using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Services
{
    public interface IPartijService
    {
        Task<IEnumerable<Partij>> GetAllPartijen();
        Task<Partij> GetPartijById(int id);
        Task<IEnumerable<Partij>> GetPartijenFromGebruikerByGebruikerId(int gebruikerId);
        Task<Partij> CreatePartij(Partij newPartij);
        Task UpdatePartij(Partij partijDieGeupdateMoetWorden, Partij partij);
        Task DeletePartij(Partij partij);
    }
}
