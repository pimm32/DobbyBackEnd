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
        private readonly IZetRepository _zetRepository;
        public ZetService(IZetRepository zetRepository)
        {
            this._zetRepository = zetRepository;
        }

        public async Task<Zet> GetZetById(int id)
        {
            return await _zetRepository
                .GetByIdAsync(id);
        }

        //public async Task<IEnumerable<Zet>> GetZettenByPartijId(int partijId)
        //{
        //    return await _unitOfWork.Zetten
        //        .GetAllWithPartijByPartijIdAsync(partijId);
        //}

        public async Task CreateZet(Zet newZet)
        {
            await _zetRepository.AddAsync(newZet);
            await _zetRepository.CommitAsync();
        }

        public async Task UpdateZet(Zet zetDieGeupdateMoetWorden, Zet zet)
        {
            zetDieGeupdateMoetWorden.BeginVeld = zet.BeginVeld;
            zetDieGeupdateMoetWorden.EindVeld = zet.EindVeld;
            zetDieGeupdateMoetWorden.PartijId = zet.PartijId;

            await _zetRepository.CommitAsync();
        }

        public async Task DeleteZet(Zet zet)
        {
            _zetRepository.Remove(zet);
            await _zetRepository.CommitAsync();
        }




    }
}
