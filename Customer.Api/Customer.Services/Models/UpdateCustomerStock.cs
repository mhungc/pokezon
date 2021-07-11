using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.CustomerApi.Services.Models
{
    public class UpdateCustomerStock
    {
        public Guid CustomerId { get; set; }
        public int Total { get; set; }
    }
}
