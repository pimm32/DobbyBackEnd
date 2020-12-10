using Dobby.Core.Models;
using Dobby.Core.Repositories;
using Dobby.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Services
{
    public class BerichtService: IBerichtService
    {
        private readonly IUnitOfWork _unitOfWork;

        public BerichtService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<IEnumerable<Bericht>> GetAllBerichten()
        {
            return await _unitOfWork.Berichten
                .GetAllAsync();
        }

        public async Task<Bericht> GetBerichtById(int id)
        {
            return await _unitOfWork.Berichten
                .GetBerichtByBerichtId(id);
        }

        public async Task<IEnumerable<Bericht>> GetBerichtenFromChatByChatId(int chatId)
        {
            return await _unitOfWork.Berichten
                .GetAllBerichtenWithChatByChatId(chatId);
        }

        public async Task<Bericht> CreateBericht(Bericht newBericht)
        {
            await _unitOfWork.Berichten.AddAsync(newBericht);
            await _unitOfWork.CommitAsync();
            return newBericht;
        }

        public async Task UpdateBericht(Bericht berichtDieGeupdateMoetWorden, Bericht bericht)
        {
            berichtDieGeupdateMoetWorden.Tekst = bericht.Tekst;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteBericht(Bericht bericht)
        {
            _unitOfWork.Berichten
                .Remove(bericht);
            await _unitOfWork.CommitAsync();
        }

    }
}
