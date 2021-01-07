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

        public async Task<PartijenCollectie> GetAllPartijen()
        {
            var partijen = await _unitOfWork.Partijen.GetAllWithZettenAsync();
            List<Partij> NietAf = new List<Partij>();
            List<Partij> Af = new List<Partij>();
            foreach (Partij partij in partijen)
            {
                foreach (Speler _speler in partij.Spelers)
                {
                    _speler.Gebruiker = await _unitOfWork.Gebruikers.GetGebruikerByGebruikerId(_speler.GebruikerId);
                }
                if(partij.Uitslag != "0")
                {
                    Af.Add(partij);
                }
                else
                {
                    NietAf.Add(partij);
                }
            }
            return new PartijenCollectie(Af, NietAf);
        }


        public async Task<PartijenCollectie> GetPartijenFromGebruikerByGebruikerId(int gebruikerId)
        {
            var spelers = await _unitOfWork.Spelers.GetAllSpelersByGebruikerId(gebruikerId);
            List<Partij> partijen = new List<Partij>();
            foreach (Speler speler in spelers)
            {
                var partij = await _unitOfWork.Partijen.GetWithZettenByIdAsync(speler.PartijId);
                foreach (Speler _speler in partij.Spelers)
                {
                    _speler.Gebruiker = await _unitOfWork.Gebruikers.GetGebruikerByGebruikerId(_speler.GebruikerId);
                }
                partijen.Add(partij);
            }
            List<Partij> NietAf = new List<Partij>();
            List<Partij> Af = new List<Partij>();
            foreach (Partij partij in partijen)
            {
                foreach (Speler _speler in partij.Spelers)
                {
                    _speler.Gebruiker = await _unitOfWork.Gebruikers.GetGebruikerByGebruikerId(_speler.GebruikerId);
                }
                if (partij.Uitslag != "0")
                {
                    Af.Add(partij);
                }
                else
                {
                    NietAf.Add(partij);
                }
            }
            return new PartijenCollectie(Af, NietAf);
        }

        public async Task<Partij> GetPartijById(int id)
        {
            var result = await _unitOfWork.Partijen.GetWithZettenByIdAsync(id);
            foreach (Speler _speler in result.Spelers)
            {
                _speler.Gebruiker = await _unitOfWork.Gebruikers.GetGebruikerByGebruikerId(_speler.GebruikerId);
            }
            if(result.Chat != null)
            {
                result.Chat.Berichten = (ICollection<Bericht>)await _unitOfWork.Berichten.GetAllBerichtenWithChatByChatId(result.Chat.Id);
                foreach (Bericht bericht in result.Chat.Berichten)
                {
                    bericht.Afzender = await _unitOfWork.Gebruikers.GetGebruikerByGebruikerId(bericht.AfzenderId);
                }
            }
            
            return result;
        }

        public async Task CreatePartij(Partij newPartij)
        {
            await _unitOfWork.Partijen.AddAsync(newPartij);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdatePartij(Partij partijDieGeupdateMoetWorden, Partij partij)
        {
            partijDieGeupdateMoetWorden.SpeeltempoMinuten = partij.SpeeltempoMinuten;
            partijDieGeupdateMoetWorden.SpeeltempoFisherSeconden = partij.SpeeltempoFisherSeconden;
            partijDieGeupdateMoetWorden.TijdWitSpeler = partij.TijdWitSpeler;
            partijDieGeupdateMoetWorden.TijdZwartSpeler = partij.TijdZwartSpeler;

            await _unitOfWork.CommitAsync();
        }

        public async Task DeletePartij(Partij partij)
        {
            _unitOfWork.Partijen.Remove(partij);

            await _unitOfWork.CommitAsync();
        }

    }
}
