using CustomerApi.Data.Repository;
using MediatR;
using Pokezon.CustomerApi.Services.Command;
using Pokezon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pokezon.CustomerAPi.Services.Command
{
    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand, Customer>
    {
        private ICustomerRepository _customerRepository;
        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            Customer customerUpdated = await _customerRepository.UpdateAsync(request.CustomerModel);
            return customerUpdated;
        }
    }
}
