using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pokezon.Services.Models
{
    public class EventOrderModel
    {
        public Guid CustomerId { get; set; }
        public decimal Total { get; set; }
    }
}
