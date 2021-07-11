using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pokezon.ProductApi.Api.Models;
using Pokezon.ProductApi.Data.Repository;
using Pokezon.ProductApi.Domain;
using Pokezon.ProductApi.Services.Command;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pokezon.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private IProductRepository _productRepository;
        private IMediator _mediator;
        private IMapper _mapper;

        public ProductController(IProductRepository productRepository, IMediator mediator, IMapper mapper)
        {
            _productRepository = productRepository;
            _mediator = mediator;
            _mapper = mapper;
        }

        // GET: api/<ProductController>
        [HttpGet]
        public Task<IEnumerable<Product>> Get()
        {
            return _productRepository.GetAll();
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ProductController>
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status422UnprocessableEntity)]
        [HttpPost]
        public async Task<ActionResult<Product>> Post([FromBody] ProductModel productModel)
        {
            try
            {
                return await _mediator.Send(new CreateProductCommand
                {
                    Product = _mapper.Map<Product>(productModel)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // PUT api/<ProductController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
