using Pokezon.Domain;
using Pokezon.OrderApi.Services.Models;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Services
{
    public interface IPokemonServices
    {
        public Task<Pokemon> CreatePokemonServices(ProductCreated productCreated);
    }
}