using Dobby.Core.Models;
using Dobby.Core.Repositories;
using Dobby.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Services
{
    public class SpelerService: ISpelerService
    {
        private readonly IUnitOfWork _unitOfWork;
        public SpelerService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork; 
        }

        public async Task<IEnumerable<Speler>> GetAllSpelersWithPartijByPartijId(int partijId)
        {
            return await _unitOfWork.Spelers
                .GetAllSpelersWithPartijByPartijId(partijId);
        }
        public async Task<IEnumerable<Speler>> GetAllSpelersByGebruikerId(int gebruikerId)
        {
            return await _unitOfWork.Spelers
                .GetAllSpelersByGebruikerId(gebruikerId);
        }
        public async Task<Speler> GetSpelerById(int id)
        {
            return await _unitOfWork.Spelers
                .GetSpelerBySpelerId(id);
        }
        public async Task<Speler> CreateSpeler(Speler newSpeler)
        {
            await _unitOfWork.Spelers.AddAsync(newSpeler);
            await _unitOfWork.CommitAsync();
            return newSpeler;
        }
        public async Task UpdateSpeler(Speler spelerDieGeupdateMoetWorden, Speler speler)
        {
            spelerDieGeupdateMoetWorden.KleurSpeler = speler.KleurSpeler;
            await _unitOfWork.CommitAsync();
        }
        public async Task DeleteSpeler(Speler speler)
        {
            _unitOfWork.Spelers.Remove(speler);
            await _unitOfWork.CommitAsync();
        }

    }
}
