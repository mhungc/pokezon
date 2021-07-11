using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokezon.Api.Controllers;
using Pokezon.OrderApi.Domain;
using Pokezon.OrderApi.Services.Command;
using Pokezon.Services.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pokezon.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _automapper;
        public OrderController(IMediator mediator, IMapper automapper)
        {
            _mediator = mediator;
            _automapper = automapper;
        }

        // GET: api/<OrderController>
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Order>>> Get()
        {
            try
            {
                return await _mediator.Send(new GetOrdersQuery());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // GET api/<OrderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<OrderController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<Order>> Post([FromBody] OrderModel orderModel)
        {
            try
            {
                return await _mediator.Send(new CreatePaymentCommand
                {
                    Order = _automapper.Map<Order>(orderModel)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
