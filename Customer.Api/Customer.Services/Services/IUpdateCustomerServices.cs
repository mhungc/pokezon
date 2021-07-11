using Pokezon.CustomerApi.Services.Models;
using Pokezon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.CustomerApi.Services.Services
{
    public interface IUpdateCustomerServices
    {
        public Task<Customer> UpdateCustomerStock(UpdateCustomerStock updateCustomerStock);
    }
}
