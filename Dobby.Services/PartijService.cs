using Dobby.Core.Models;
using Dobby.Core.Repositories;
using Dobby.Core.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Dobby.Services
{
    public class PartijService: IPartijService
    {
        private readonly IUnitOfWork _unitOfWork;

        public PartijService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<IEnumerable<Partij>> GetAllPartijen()
        {
            return await _unitOfWork.Partijen.GetAllAsync();
        }


        public async Task<IEnumerable<Partij>> GetPartijenFromGebruikerByGebruikerId(int gebruikerId)
        {
            return await _unitOfWork.Partijen.GetAllByPlayerWithZettenAsync(gebruikerId);
        }

        public async Task<Partij> GetPartijById(int id)
        {
            return await _unitOfWork.Partijen.GetByIdAsync(id);
        }

        public async Task<Partij> CreatePartij(Partij newPartij)
        {
            await _unitOfWork.Partijen.AddAsync(newPartij);
            return newPartij;
        }

        public async Task UpdatePartij(Partij partijDieGeupdateMoetWorden, Partij partij)
        {
            partijDieGeupdateMoetWorden.Spelers = partij.Spelers;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePartij(Partij partij)
        {
            _unitOfWork.Partijen.Remove(partij);

            await _unitOfWork.CommitAsync();
        }

    }
}
