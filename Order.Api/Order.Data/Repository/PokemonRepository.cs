using Pokezon.Data.Repository;
using Pokezon.Domain;
using Pokezon.OrderApi.Data.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Data.Repository
{
    public class PokemonRepository : Repository<Pokemon>, IPokemonRepository
    {
        public PokemonRepository(OrderContext orderContext) : base(orderContext)
        {
        }

       
    }
}
