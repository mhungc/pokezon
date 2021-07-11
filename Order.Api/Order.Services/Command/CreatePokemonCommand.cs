using MediatR;
using Pokezon.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Services.Command
{
    public class CreatePokemonCommand : IRequest<Pokemon>
    {
        public Pokemon Pokemon { get; set; }
    }
}
