using Pokezon.Domain;
using Pokezon.OrderApi.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.Data.Repository
{
    public interface IPokemonRepository : IRepository<Pokemon>
    {
    }
}
