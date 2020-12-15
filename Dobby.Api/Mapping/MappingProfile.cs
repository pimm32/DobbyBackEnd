using AutoMapper;
using Dobby.Api.Resources;
using Dobby.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dobby.Api.Mapping
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            // Domain to Resource
            CreateMap<Zet, ZetResource>();
            CreateMap<Partij, PartijResource>();
            CreateMap<Partij, SavePartijResource>();
            CreateMap<Zet, SaveZetResource>();
            CreateMap<Bericht, BerichtResource>();
            CreateMap<Bericht, SaveBerichtResource>();
            CreateMap<Chat, ChatResource>();
            CreateMap<Chat, SaveChatResource>();
            CreateMap<Gebruiker, GebruikerResource>();
            CreateMap<Gebruiker, SaveGebruikerResource>();
            CreateMap<Speler, SpelerResource>();
            CreateMap<Speler, SaveSpelerResource>();

            // Resource to Domain
            CreateMap<PartijResource, Partij>();
            CreateMap<ZetResource, Zet>();
            CreateMap<SaveZetResource, Zet>();
            CreateMap<SavePartijResource, Partij>();
            CreateMap<BerichtResource, Bericht>();
            CreateMap<SaveBerichtResource, Bericht>();
            CreateMap<ChatResource, Chat>();
            CreateMap<SaveChatResource, Chat>();
            CreateMap<GebruikerResource, Gebruiker>();
            CreateMap<SaveGebruikerResource, Gebruiker>();
            CreateMap<SpelerResource, Speler>();
            CreateMap<SaveSpelerResource, Speler>();

        }
    }
}
