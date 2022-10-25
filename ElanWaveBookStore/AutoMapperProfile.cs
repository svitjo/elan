using ElanWaveBookStore.DTO;
using ElanWaveBookStore.Models;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ElanWaveBookStore
{
    public class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<User, DTOGetUser>();
            CreateMap<DTOAddUser, User>();
        }
    }
}
