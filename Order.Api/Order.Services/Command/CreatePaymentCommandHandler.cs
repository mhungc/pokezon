using Azure.Core.Serialization;
using Azure.Messaging.EventGrid;
using MediatR;
using Microsoft.Extensions.Configuration;
using Pokezon.OrderApi.Data.Repository;
using Pokezon.OrderApi.Domain;
using Pokezon.OrderApi.Services.Command;
using Pokezon.OrderApi.Services.EventBus;
using Pokezon.Services.Models;
using Popkezon.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Services.Command
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Order>
    {
        private IConfiguration _configuration;
        private IOrderRepository _orderRepository;
        private IOrderDetailsRepository _orderDetailsRepository;
        public CreatePaymentCommandHandler(IConfiguration configuration, IOrderRepository orderRepository, IOrderDetailsRepository orderDetailsRepository)
        {
            _configuration = configuration;
            _orderRepository = orderRepository;
            _orderDetailsRepository = orderDetailsRepository;
        }

        public async Task<Order> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.AddAsync(request.Order);

            var eventGridClient = EventGridServices.CreateClient(_configuration["EventGrid:EndpointUrl"], _configuration["EventGrid:EventKeyAccessKey"]);

            var customDataSerializer = new JsonObjectSerializer(
                new JsonSerializerOptions()
                {
                    PropertyNamingPolicy = JsonNamingPolicy.CamelCase
                }
            );

            var customJson = await customDataSerializer.SerializeAsync(new EventOrderModel
            {
                CustomerId = order.CustomerId,
                Total = order.Total
            });

            var eventGridEvent = new EventGridEvent(
                "ExampleEventSubjectCustomer",
                "UpdateCustomer",
                "1.0",
                customJson
                );

            await eventGridClient.SendEventAsync(eventGridEvent, cancellationToken);

            return order;

        }
    }
}
