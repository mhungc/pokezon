using Microsoft.AspNetCore.Mvc;
using Pokezon.ProductApi.Data.Repository;
using Pokezon.ProductApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pokezon.ProductApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private IProductRepository _productRepository;

        public ValuesController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        // GET: api/<ValuesController>
        [HttpGet]
        public Task<IEnumerable<Product>> Get()
        {
            return _productRepository.GetAll();
        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
