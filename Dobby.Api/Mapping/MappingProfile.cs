﻿using AutoMapper;
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

            // Resource to Domain
            CreateMap<PartijResource, Partij>();
            CreateMap<ZetResource, Zet>();
            CreateMap<SaveZetResource, Zet>();
            CreateMap<SavePartijResource, Partij>();

        }
    }
}
