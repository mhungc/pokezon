using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Pokezon.Api.Infrastructure.Constants;
using Pokezon.OrderApi.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using System.IO;
using System.Text;
using Pokezon.OrderApi.Services.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Pokezon.OrderApi.Controllers
{
    [Route("/api/webhooks"), AllowAnonymous]
    [ApiController]
    public class OrderWebhooksController : ControllerBase
    {
        private IMediator _mediator;
        private IMapper _mapper;
        private IPokemonServices _pokemonServices;

        public OrderWebhooksController(IMediator mediator, IMapper mapper, IPokemonServices pokemonServices)
        {
            _mediator = mediator;
            _mapper = mapper;
            _pokemonServices = pokemonServices;
        }

        [HttpPost("handle_ams_jobchanged")]
        public async Task<IActionResult> ProcessAMSEventAsync([FromBody] EventGridEvent[] ev,
         [FromServices] ILogger<OrderWebhooksController> logger)
        {

            var amsEvent = ev.FirstOrDefault();
            if (amsEvent == null) return BadRequest();


            foreach (EventGridEvent eventGridEvent in ev)
            {
                var eventDataJson = (JsonElement)eventGridEvent.Data;

                //Validate whether EventType is a SubscriptionValidationEvent
                if (eventGridEvent.EventType == Constants.SubscriptionValidationEvent)
                {
                    var property1 = eventDataJson.GetProperty("validationUrl").GetString();
                    var property2 = eventDataJson.GetProperty("validationCode").GetString();

                    logger.LogInformation($"Got SubscriptionValidation event data, validation code: {property1}, topic: {eventGridEvent.Topic}");

                    var responseData = new SubscriptionValidationResponse()
                    {
                        ValidationResponse = property2
                    };
                    return new OkObjectResult(responseData);
                }
                else
                {
                    if (eventGridEvent.EventType == Constants.ProductCreated)
                    {
                        var productId = Guid.Parse(eventDataJson.GetProperty("productId").GetString());
                        var name = eventDataJson.GetProperty("name").GetString();
                        var productModel = new ProductCreated()
                        {
                            ProductId = productId,
                            Name = name
                        };

                        var productUpdated = await _pokemonServices.CreatePokemonServices(productModel);

                        //var product = await _mediator.Send(new UpdateCustomerCommand()
                        //{
                        //    CustomerModel = new Domain.Entities.Customer()
                        //    {
                        //        Id = productModel.CustomerId,
                        //        Total = productModel.Total
                        //    }
                        //});

                        return new OkObjectResult(productUpdated);
                    }
                }

            }

            return BadRequest();
        }

    }
}
