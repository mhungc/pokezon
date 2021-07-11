using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Pokezon.ProductApi.Domain;
using Pokezon.ProductApi.Api.Models;

namespace Pokezon.Api.Infrastructure.Automapper
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ProductModel, Product>();
        }
    }
}
