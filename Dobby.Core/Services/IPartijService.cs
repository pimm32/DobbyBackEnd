using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Core.Services
{
    public interface IPartijService
    {
        Task<PartijenCollectie> GetAllPartijen();
        Task<Partij> GetPartijById(int id);
        Task<PartijenCollectie> GetPartijenFromGebruikerByGebruikerId(int gebruikerId);
        Task CreatePartij(Partij newPartij);
        Task UpdatePartij(Partij partijDieGeupdateMoetWorden, Partij partij);
        Task DeletePartij(Partij partij);
    }
}
