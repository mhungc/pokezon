using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.EventGrid;
using Microsoft.Azure.EventGrid.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Text.Json;
using Pokezon.Api.Infrastructure.Constants;
using MediatR;
using AutoMapper;
using Pokezon.CustomerApi.Services.Command;
using Pokezon.CustomerApi.Services.Services;
using Pokezon.CustomerApi.Services.Models;

namespace Pokezon.Api.Controllers
{
    [Route("/api/webhooks"), AllowAnonymous]
    public class CustomerWebhooksController : Controller
    {
        private IMediator _mediator;
        private IMapper _mapper;
        private IUpdateCustomerServices _updateCustomerServices;

        public CustomerWebhooksController(IMediator mediator, IMapper mapper, IUpdateCustomerServices updateCustomerServices)
        {
            _mediator = mediator;
            _mapper = mapper;
            _updateCustomerServices = updateCustomerServices;
        }

        // POST: /api/webhooks/handle_ams_jobchanged
        [HttpPost("handle_ams_jobchanged")]
        public async Task<IActionResult> ProcessAMSEventAsync(
           [FromBody] EventGridEvent[] ev,
            [FromServices] ILogger<CustomerWebhooksController> logger)
        {
            var amsEvent = ev.FirstOrDefault();
            if (amsEvent == null) return BadRequest();


            foreach (EventGridEvent eventGridEvent in ev)
            {
                var eventDataJson = (System.Text.Json.JsonElement)eventGridEvent.Data;

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
                    if (eventGridEvent.EventType == Constants.UpdateCustomer)
                    {
                        var customerId = Guid.Parse(eventDataJson.GetProperty("customerId").GetString());
                        var total = eventDataJson.GetProperty("total").GetInt32();
                        var customerModel = new UpdateCustomerStock()
                        {
                            CustomerId = customerId,
                            Total = total
                        };

                        var customerUpdated = await _updateCustomerServices.UpdateCustomerStock(customerModel);

                        //var customer = await _mediator.Send(new UpdateCustomerCommand()
                        //{
                        //    CustomerModel = new Domain.Entities.Customer()
                        //    {
                        //        Id = customerModel.CustomerId,
                        //        Total = customerModel.Total
                        //    }
                        //});

                        return new OkObjectResult(customerUpdated);
                    }
                }

            }

            return BadRequest();
        }
    }
}
