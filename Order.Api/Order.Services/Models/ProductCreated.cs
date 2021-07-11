using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Services.Models
{
    public class ProductCreated
    {
        public Guid ProductId { get; set; }
        public string Name { get; set; }

    }
}
