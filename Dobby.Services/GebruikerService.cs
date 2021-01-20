using Dobby.Core.Models;
using Dobby.Core.Repositories;
using Dobby.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Services
{
    public class GebruikerService: IGebruikerService
    {
        private readonly IGebruikerRepository _gebruikerRepository;
        public GebruikerService(IGebruikerRepository gebruikerRepository)
        {
            this._gebruikerRepository = gebruikerRepository;
        }
        public async Task<IEnumerable<Gebruiker>> GetAllGebruikers()
        {
            return await _gebruikerRepository
                .GetAllGebruikers();
        }
        //public async Task<IEnumerable<GebruikerContact>> GetAllContactsFromGebruikerByGebruikerId(int gebruikerId)
        //{
        //    return await _unitOfWork.Gebruikers
        //        .GetAllContactsOfGebruikerByGebruikerId(gebruikerId);
        //}
        public async Task<Gebruiker> GetGebruikerById(int id)
        {
            return await _gebruikerRepository
                .GetGebruikerByGebruikerId(id);
        }
        public async Task<Gebruiker> GetGebruikerByEmail(string email)
        {
            return await _gebruikerRepository.GetGebruikerByEmail(email);
        }
        public async Task<Gebruiker> CreateGebruiker(Gebruiker newGebruiker)
        {
            await _gebruikerRepository.AddAsync(newGebruiker);
            await _gebruikerRepository.CommitAsync();
            return newGebruiker;
        }
        public async Task UpdateGebruiker(Gebruiker gebruikerDieGeupdateMoetWorden, Gebruiker gebruiker)
        {
            gebruikerDieGeupdateMoetWorden.Gebruikersnaam = gebruiker.Gebruikersnaam;
            gebruikerDieGeupdateMoetWorden.Email = gebruiker.Email;
            gebruikerDieGeupdateMoetWorden.Rating = gebruiker.Rating;
            await _gebruikerRepository.CommitAsync();
        }
        public async Task DeleteGebruiker(Gebruiker gebruiker)
        {
            _gebruikerRepository.Remove(gebruiker);
            await _gebruikerRepository.CommitAsync();
        }

    }
}
