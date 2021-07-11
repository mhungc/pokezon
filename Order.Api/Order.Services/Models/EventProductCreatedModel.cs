using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokezon.Services.Models
{
    public class EventProductCreatedModel
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }
    }
}
