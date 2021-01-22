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
            var partijen = await _partijRepository.GetAllWithZettenAsync() as List<Partij>;
            foreach (Partij partij in partijen)
            {
                foreach (Speler _speler in partij.Spelers)
                {
                    _speler.Gebruiker = await _gebruikerRepository.GetGebruikerByGebruikerId(_speler.GebruikerId);
                }
                if (partij.Chat != null)
                {
                    partij.Chat.Berichten = (ICollection<Bericht>)await _berichtRepository.GetAllBerichtenWithChatByChatId(partij.Chat.Id);
                    foreach (Bericht bericht in partij.Chat.Berichten)
                    {
                        bericht.Afzender = await _gebruikerRepository.GetGebruikerByGebruikerId(bericht.AfzenderId);
                    }
                }
            }
            return new PartijenCollectie(AllePartijenDieAfZijn(partijen), AllePartijenDieNietAfZijn(partijen));
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
                if (partij.Chat != null)
                {
                    partij.Chat.Berichten = (ICollection<Bericht>)await _berichtRepository.GetAllBerichtenWithChatByChatId(partij.Chat.Id);
                    foreach (Bericht bericht in partij.Chat.Berichten)
                    {
                        bericht.Afzender = await _gebruikerRepository.GetGebruikerByGebruikerId(bericht.AfzenderId);
                    }
                }
                partijen.Add(partij);
            }
            
            return new PartijenCollectie(AllePartijenDieAfZijn(partijen), AllePartijenDieNietAfZijn(partijen));
        }

        public ICollection<Partij> AllePartijenDieAfZijn(ICollection<Partij> partijen)
        {
            ICollection<Partij> result = new List<Partij>();
            foreach (Partij partij in partijen)
            {
                if (partij.Uitslag == "2-0" || partij.Uitslag == "1-1" || partij.Uitslag == "0-2")
                {
                    result.Add(partij);
                }
            }

            return result;
        }

        public ICollection<Partij> AllePartijenDieNietAfZijn(ICollection<Partij> partijen)
        {
            ICollection<Partij> result = new List<Partij>();
            foreach (Partij partij in partijen)
            {
                if (partij.Uitslag == "0" || partij.Uitslag == null)
                {
                    result.Add(partij);
                }
            }

            return result;
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

        public async Task<Partij> CreatePartij(Partij newPartij)
        {
            await _partijRepository.AddAsync(newPartij);
            await _partijRepository.CommitAsync();
            var partijen = await _partijRepository.GetAllWithZettenAsync() as List<Partij>;
            return partijen[partijen.Count - 1];
            
        }

        public async Task UpdatePartij(Partij partijDieGeupdateMoetWorden, Partij partij)
        {
            partijDieGeupdateMoetWorden.TijdWitSpeler = partij.TijdWitSpeler;
            partijDieGeupdateMoetWorden.TijdZwartSpeler = partij.TijdZwartSpeler;
            partijDieGeupdateMoetWorden.Uitslag = partij.Uitslag;
            if(partijDieGeupdateMoetWorden.Uitslag != partij.Uitslag)
            {
                GebruikerService _service = new GebruikerService(_gebruikerRepository);
                var spelers = await _spelerRepository.GetAllSpelersWithPartijByPartijId(partijDieGeupdateMoetWorden.Id) as List<Speler>;
                var witSpeler = new Speler();
                var zwartSpeler = new Speler();
                foreach (Speler speler in spelers)
                {
                    if(speler.KleurSpeler == "wit")
                    {
                        witSpeler = speler;
                    }
                    else
                    {
                        zwartSpeler = speler;
                    }
                }
                foreach (Speler speler in spelers)
                {

                    var gebruiker = await _gebruikerRepository.GetGebruikerByGebruikerId(speler.GebruikerId);
                    await _service.UpdateGebruiker(gebruiker, new Gebruiker { Id = gebruiker.Id, Gebruikersnaam = gebruiker.Gebruikersnaam, Email = gebruiker.Email, Rating = gebruiker.Rating + BerekenRatingVerschil(witSpeler.RatingAanBeginVanWedstrijd, zwartSpeler.RatingAanBeginVanWedstrijd, partij.Uitslag, speler.KleurSpeler) });
                }
            }

            await _partijRepository.CommitAsync();
        }

        public int BerekenRatingVerschil(decimal rating1, decimal rating2, string uitslag, string kleur)
        {
            if (uitslag == "0-2")
            {
                if (kleur == "wit")
                {
                    return (int)(5 * (rating2 / rating1));
                }
                else
                {
                    return (int)(5 * (rating1 / rating2));
                }
            }
            else if (uitslag == "2-0")
            {
                if (kleur == "wit")
                {
                    return (int)(5 * (rating2 / rating1));
                }
                else
                {
                    return (int)(5 * (rating1 / rating2));
                }
            }
            else
            {
                if (rating1 == rating2)
                {
                    return 0;
                }
                else if (rating1 > rating2)
                {
                    if (kleur == "wit")
                    {
                        return (int)(-1 * (rating1 / rating2));
                    }
                    else
                    {
                        return (int)(1 * (rating1 / rating2));
                    }
                }
                else
                {
                    if (kleur == "wit")
                    {
                        return (int)(1 * (rating2/ rating1));
                    }
                    else
                    {
                        return (int)(-1 * (rating2 / rating1));
                    }
                }
            }
        }

        public async Task DeletePartij(Partij partij)
        {
            _partijRepository.Remove(partij);

            await _partijRepository.CommitAsync();
        }

    }
}
