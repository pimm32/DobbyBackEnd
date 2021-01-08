using Dobby.Core.Models;
using Dobby.Core.Repositories;
using Dobby.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Services
{
    public class BerichtService : IBerichtService
    {
        private readonly IBerichtRepository _berichtRepository;

        public BerichtService(IBerichtRepository berichtRepository)
        {
            this._berichtRepository = berichtRepository;
        }
        //public async Task<IEnumerable<Bericht>> GetAllBerichten()
        //{
        //    return await _unitOfWork.Berichten
        //        .GetAllAsync();
        //}

        public async Task<Bericht> GetBerichtById(int id)
        {
            return await _berichtRepository
                .GetBerichtByBerichtId(id);
        }

        public async Task<IEnumerable<Bericht>> GetBerichtenFromChatByChatId(int chatId)
        {
            return await _berichtRepository
                .GetAllBerichtenWithChatByChatId(chatId);
        }

        public async Task<Bericht> CreateBericht(Bericht newBericht)
        {
            await _berichtRepository.AddAsync(newBericht);
            await _berichtRepository.CommitAsync();
            return newBericht;
        }

        public async Task UpdateBericht(Bericht berichtDieGeupdateMoetWorden, Bericht bericht)
        {
            berichtDieGeupdateMoetWorden.Tekst = bericht.Tekst;

            await _berichtRepository.CommitAsync();
        }

        public async Task DeleteBericht(Bericht bericht)
        {
            _berichtRepository
                .Remove(bericht);
            await _berichtRepository.CommitAsync();
        }
    }
}
