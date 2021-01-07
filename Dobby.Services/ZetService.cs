using Dobby.Core.Models;
using Dobby.Core.Repositories;
using Dobby.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Services
{
    public class ZetService: IZetService
    {
        private readonly IUnitOfWork _unitOfWork;
        public ZetService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Zet> GetZetById(int id)
        {
            return await _unitOfWork.Zetten
                .GetByIdAsync(id);
        }

        public async Task<IEnumerable<Zet>> GetZettenByPartijId(int partijId)
        {
            return await _unitOfWork.Zetten
                .GetAllWithPartijByPartijIdAsync(partijId);
        }

        public async Task CreateZet(Zet newZet)
        {
            await _unitOfWork.Zetten.AddAsync(newZet);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateZet(Zet zetDieGeupdateMoetWorden, Zet zet)
        {
            zetDieGeupdateMoetWorden.BeginVeld = zet.BeginVeld;
            zetDieGeupdateMoetWorden.EindVeld = zet.EindVeld;
            zetDieGeupdateMoetWorden.PartijId = zet.PartijId;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeleteZet(Zet zet)
        {
            _unitOfWork.Zetten.Remove(zet);
            await _unitOfWork.CommitAsync();
        }




    }
}
