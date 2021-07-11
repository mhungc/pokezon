using MediatR;

using Pokezon.Data.Repository;
using Pokezon.Domain;
using Pokezon.OrderApi.Services.Command;
using Pokezon.OrderApi.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Services.Services
{
    public class PokemonServices : IPokemonServices
    {
        private IPokemonRepository _pokemonRepository;
        private IMediator _mediator;

        public PokemonServices(IMediator mediator, IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
            _mediator = mediator;
        }


        public async Task<Pokemon> CreatePokemonServices(ProductCreated productCreated)
        {
            return await _mediator.Send(new CreatePokemonCommand
            {
                Pokemon = new Pokemon()
                {
                    Id = productCreated.ProductId,
                    Name = productCreated.Name,
                    Price = 0
                }
            });

        }
    }
}
