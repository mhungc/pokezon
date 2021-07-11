using CustomerApi.Data.Repository;
using MediatR;
using Pokezon.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pokezon.Services.Query
{
    public class GetCustomerByIdQueryHanlder: IRequestHandler<GetCustomerByIdQuery,Customer>
    {
        private readonly ICustomerRepository _customerRepository;

        public GetCustomerByIdQueryHanlder(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Customer> Handle(GetCustomerByIdQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.GetCustomerByIdAsync(request.Id, cancellationToken);
        }

    }
}
