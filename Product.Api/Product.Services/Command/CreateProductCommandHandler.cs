using Azure.Core.Serialization;
using Azure.Messaging.EventGrid;
using MediatR;
using Microsoft.Extensions.Configuration;
using Pokezon.ProductApi.Data.Repository;
using Pokezon.ProductApi.Domain;
using Pokezon.ProductApi.Services.EventBus;
using Pokezon.Services.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Pokezon.ProductApi.Services.Command
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Product>
    {
        private IProductRepository _productRepository;
        private IConfiguration _configuration;

        public CreateProductCommandHandler(IConfiguration configuration, IProductRepository productRepository)
        {
            _productRepository = productRepository;
            _configuration = configuration;
        }

        public async Task<Product> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.CreateProduct(request.Product);

            var eventGridClient = EventGridServices.CreateClient(_configuration["EventGrid:EndpointUrl"], _configuration["EventGrid:EventKeyAccessKey"]);

            var customDataSerializer = new JsonObjectSerializer(
               new JsonSerializerOptions()
               {
                   PropertyNamingPolicy = JsonNamingPolicy.CamelCase
               }
           );

            var customJson = await customDataSerializer.SerializeAsync(new EventProductCreatedModel
            {
                ProductId = request.Product.ProductId,
                Name = request.Product.Name
            });

            var eventGridEvent = new EventGridEvent(
               "ExampleEventSubjectCustomer",
               "ProductCreated",
               "1.0",
               customJson
               );

            await eventGridClient.SendEventAsync(eventGridEvent, cancellationToken);

            return product;

        }
    }
}
