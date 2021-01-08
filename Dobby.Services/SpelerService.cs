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
        private readonly ISpelerRepository _spelerRepository;
        public SpelerService(ISpelerRepository spelerRepository)
        {
            this._spelerRepository = spelerRepository; 
        }

        //public async Task<IEnumerable<Speler>> GetAllSpelersWithPartijByPartijId(int partijId)
        //{
        //    return await _unitOfWork.Spelers
        //        .GetAllSpelersWithPartijByPartijId(partijId);
        //}
        //public async Task<IEnumerable<Speler>> GetAllSpelersByGebruikerId(int gebruikerId)
        //{
        //    return await _unitOfWork.Spelers
        //        .GetAllSpelersByGebruikerId(gebruikerId);
        //}
        public async Task<Speler> GetSpelerById(int id)
        {
            return await _spelerRepository
                .GetSpelerBySpelerId(id);
        }
        public async Task<Speler> CreateSpeler(Speler newSpeler)
        {
            await _spelerRepository.AddAsync(newSpeler);
            await _spelerRepository.CommitAsync();
            return newSpeler;
        }
        public async Task UpdateSpeler(Speler spelerDieGeupdateMoetWorden, Speler speler)
        {
            spelerDieGeupdateMoetWorden.KleurSpeler = speler.KleurSpeler;
            await _spelerRepository.CommitAsync();
        }
        public async Task DeleteSpeler(Speler speler)
        {
            _spelerRepository.Remove(speler);
            await _spelerRepository.CommitAsync();
        }

    }
}
