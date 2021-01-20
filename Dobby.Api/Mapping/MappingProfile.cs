namespace Dobby.Api.Mapping
{
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using AutoMapper;
    using Dobby.Api.Resources;
    using Dobby.Core.Models;

    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            this.CreateMap<Zet, ZetResource>();
            this.CreateMap<Partij, PartijResource>();
            this.CreateMap<Partij, SavePartijResource>();
            this.CreateMap<Zet, SaveZetResource>();
            this.CreateMap<Bericht, BerichtResource>();
            this.CreateMap<Bericht, SaveBerichtResource>();
            this.CreateMap<Chat, ChatResource>();
            this.CreateMap<Chat, SaveChatResource>();
            this.CreateMap<Gebruiker, GebruikerResource>();
            this.CreateMap<Gebruiker, SaveGebruikerResource>();
            this.CreateMap<Speler, SpelerResource>();
            this.CreateMap<Speler, SaveSpelerResource>();
            this.CreateMap<PartijenCollectie, PartijenCollectieResource>();
            this.CreateMap<GebruikerContact, SaveContactResource>();


            // Resource to Domain
            this.CreateMap<PartijResource, Partij>();
            this.CreateMap<ZetResource, Zet>();
            this.CreateMap<SaveZetResource, Zet>();
            this.CreateMap<SavePartijResource, Partij>();
            this.CreateMap<BerichtResource, Bericht>();
            this.CreateMap<SaveBerichtResource, Bericht>();
            this.CreateMap<ChatResource, Chat>();
            this.CreateMap<SaveChatResource, Chat>();
            this.CreateMap<GebruikerResource, Gebruiker>();
            this.CreateMap<SaveGebruikerResource, Gebruiker>();
            this.CreateMap<SpelerResource, Speler>();
            this.CreateMap<SaveSpelerResource, Speler>();
            this.CreateMap<PartijenCollectieResource, PartijenCollectie>();
            this.CreateMap<SaveContactResource, GebruikerContact>();
        }
    }
}
