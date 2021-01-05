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
        private readonly IUnitOfWork _unitOfWork;
        public GebruikerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Gebruiker>> GetAllGebruikers()
        {
            return await _unitOfWork.Gebruikers
                .GetAllGebruikers();
        }
        public async Task<IEnumerable<GebruikerContact>> GetAllContactsFromGebruikerByGebruikerId(int gebruikerId)
        {
            return await _unitOfWork.Gebruikers
                .GetAllContactsOfGebruikerByGebruikerId(gebruikerId);
        }
        public async Task<Gebruiker> GetGebruikerById(int id)
        {
            return await _unitOfWork.Gebruikers
                .GetGebruikerByGebruikerId(id);
        }
        public async Task<Gebruiker> CreateGebruiker(Gebruiker newGebruiker)
        {
            await _unitOfWork.Gebruikers.AddAsync(newGebruiker);
            await _unitOfWork.CommitAsync();
            return newGebruiker;
        }
        public async Task UpdateGebruiker(Gebruiker gebruikerDieGeupdateMoetWorden, Gebruiker gebruiker)
        {
            gebruikerDieGeupdateMoetWorden.Gebruikersnaam = gebruiker.Gebruikersnaam;
            gebruikerDieGeupdateMoetWorden.Rating = gebruiker.Rating;
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteGebruiker(Gebruiker gebruiker)
        {
            _unitOfWork.Gebruikers.Remove(gebruiker);
            await _unitOfWork.CommitAsync();
        }

    }
}
