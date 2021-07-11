using AutoMapper;
using Pokezon.Api.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokezon.OrderApi.Domain;

namespace Pokezon.Api.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<OrderModel, Order>()
                 .ForMember(dst => dst.OrderDetails, opt => opt.MapFrom(src => src.OrderDetails));
         
        }
    }
}
