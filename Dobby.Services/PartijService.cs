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
        private readonly IPartijRepository _partijRepository;
        private readonly ISpelerRepository _spelerRepository;
        private readonly IGebruikerRepository _gebruikerRepository;
        private readonly IBerichtRepository _berichtRepository;

        public PartijService(IPartijRepository partijRepository, ISpelerRepository spelerRepository, IGebruikerRepository gebruikerRepository, IBerichtRepository berichtRepository)
        {
            this._partijRepository = partijRepository;
            this._spelerRepository = spelerRepository;
            this._gebruikerRepository = gebruikerRepository;
            this._berichtRepository = berichtRepository;
        }

        public async Task<PartijenCollectie> GetAllPartijen()
        {
            var partijen = await _partijRepository.GetAllWithZettenAsync();
            List<Partij> NietAf = new List<Partij>();
            List<Partij> Af = new List<Partij>();
            foreach (Partij partij in partijen)
            {
                foreach (Speler _speler in partij.Spelers)
                {
                    _speler.Gebruiker = await _gebruikerRepository.GetGebruikerByGebruikerId(_speler.GebruikerId);
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
            //logica om spelers van gebruikers op te halen verplaatsen naar service SpelerService
            var spelers = await _spelerRepository.GetAllSpelersByGebruikerId(gebruikerId);
            List<Partij> partijen = new List<Partij>();
            foreach (Speler speler in spelers)
            {
                var partij = await _partijRepository.GetWithZettenByIdAsync(speler.PartijId);
                foreach (Speler _speler in partij.Spelers)
                {
                    _speler.Gebruiker = await _gebruikerRepository.GetGebruikerByGebruikerId(_speler.GebruikerId);
                }
                partijen.Add(partij);
            }
            List<Partij> NietAf = new List<Partij>();
            List<Partij> Af = new List<Partij>();
            //lostrekken in methodes
            foreach (Partij partij in partijen)
            {
                foreach (Speler _speler in partij.Spelers)
                {
                    _speler.Gebruiker = await _gebruikerRepository.GetGebruikerByGebruikerId(_speler.GebruikerId);
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
            var result = await _partijRepository.GetWithZettenByIdAsync(id);
            foreach (Speler _speler in result.Spelers)
            {
                _speler.Gebruiker = await _gebruikerRepository.GetGebruikerByGebruikerId(_speler.GebruikerId);
            }
            if(result.Chat != null)
            {
                result.Chat.Berichten = (ICollection<Bericht>)await _berichtRepository.GetAllBerichtenWithChatByChatId(result.Chat.Id);
                foreach (Bericht bericht in result.Chat.Berichten)
                {
                    bericht.Afzender = await _gebruikerRepository.GetGebruikerByGebruikerId(bericht.AfzenderId);
                }
            }
            
            return result;
        }

        public async Task CreatePartij(Partij newPartij)
        {
            await _partijRepository.AddAsync(newPartij);
            await _partijRepository.CommitAsync();
        }

        public async Task UpdatePartij(Partij partijDieGeupdateMoetWorden, Partij partij)
        {
            partijDieGeupdateMoetWorden.SpeeltempoMinuten = partij.SpeeltempoMinuten;
            partijDieGeupdateMoetWorden.SpeeltempoFisherSeconden = partij.SpeeltempoFisherSeconden;
            partijDieGeupdateMoetWorden.TijdWitSpeler = partij.TijdWitSpeler;
            partijDieGeupdateMoetWorden.TijdZwartSpeler = partij.TijdZwartSpeler;

            await _partijRepository.CommitAsync();
        }

        public async Task DeletePartij(Partij partij)
        {
            _partijRepository.Remove(partij);

            await _partijRepository.CommitAsync();
        }

    }
}
