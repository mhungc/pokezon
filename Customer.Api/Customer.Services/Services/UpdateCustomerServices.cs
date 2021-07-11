using CustomerApi.Data.Repository;
using MediatR;
using Pokezon.CustomerApi.Services.Command;
using Pokezon.CustomerApi.Services.Models;
using Pokezon.CustomerApi.Services.Services;
using Pokezon.Domain.Entities;
using Pokezon.Services.Query;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.CustomerAPi.Services.Services
{
    public class UpdateCustomerServices : IUpdateCustomerServices
    {

        private IMediator _mediator;
        private ICustomerRepository _customerRepository;
        public UpdateCustomerServices(IMediator mediator, ICustomerRepository customerRepository)
        {
            _mediator = mediator;
            _customerRepository = customerRepository;
        }

        public async Task<Customer> UpdateCustomerStock(UpdateCustomerStock updateCustomerStock)
        {
            Customer customer = await _mediator.Send(new GetCustomerByIdQuery
            {
                Id = updateCustomerStock.CustomerId
            });

            customer.Total = updateCustomerStock.Total;

            return await _mediator.Send(new UpdateCustomerCommand()
            {
                CustomerModel = customer
            });
        }
    }
}
