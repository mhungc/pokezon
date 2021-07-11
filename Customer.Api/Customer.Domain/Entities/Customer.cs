using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.Domain.Entities
{
    public partial class Customer
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? Birthday { get; set; }
        public int? Age { get; set; }
        public int PokeCollection { get; set; }
        public int Total { get; set; }
    }
}
