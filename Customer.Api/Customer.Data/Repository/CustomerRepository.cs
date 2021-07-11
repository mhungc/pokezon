using Microsoft.EntityFrameworkCore;
using Pokezon.CustomerApi.Data.Database;
using Pokezon.Data.Repository;
using Pokezon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CustomerApi.Data.Repository
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        public CustomerRepository(CustomerContext customerContext) : base(customerContext)
        {
        }

        public async Task<Customer> GetCustomerByIdAsync(Guid id, CancellationToken cancellationToken)
        {
            return await CustomerContext.Customer.FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }
    }
}
