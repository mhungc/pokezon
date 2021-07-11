using MediatR;
using Pokezon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.CustomerApi.Services.Command
{
    public class UpdateCustomerCommand : IRequest<Customer>
    {
        public Customer CustomerModel { get; set; }
    }
}
