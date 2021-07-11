using MediatR;
using Pokezon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.Services.Query
{
    public class GetCustomerByIdQuery: IRequest<Customer>
    {
        public Guid Id { get; set; }
    }
}
