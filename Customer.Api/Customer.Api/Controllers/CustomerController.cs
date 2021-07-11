using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Azure.EventGrid.Models;
using Pokezon.Domain.Entities;
using Pokezon.Services.Query;

namespace Pokezon.Api.Controllers
{


    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CustomerController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<List<Customer>>> Customers()
        {
            try
            {
                return await _mediator.Send(new GetCustomersQuery());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [HttpGet, Route("{id}")]
        public async Task<ActionResult<Customer>> Customer(Guid id)
        {
            try
            {
                var queryByCustomer = new GetCustomerByIdQuery()
                {
                    Id = id
                };

                return await _mediator.Send(queryByCustomer);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public void Customer([FromBody] EventGridEvent[] value)
        {
            var test = "";
        }
    }
}
