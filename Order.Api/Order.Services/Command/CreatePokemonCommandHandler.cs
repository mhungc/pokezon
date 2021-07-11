using MediatR;
using Pokezon.Data.Repository;
using Pokezon.Domain;
using Pokezon.OrderApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Services.Command
{
    public class CreatePokemonCommandHandler : IRequestHandler<CreatePokemonCommand, Pokemon>
    {
        private IPokemonRepository _pokemonRepository;

        public CreatePokemonCommandHandler(IPokemonRepository pokemonRepository)
        {
            _pokemonRepository = pokemonRepository;
        }

        public Task<Pokemon> Handle(CreatePokemonCommand request, CancellationToken cancellationToken) => _pokemonRepository.AddAsync(request.Pokemon);
    }
}
