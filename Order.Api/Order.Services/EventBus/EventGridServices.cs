using Azure;
using Azure.Messaging.EventGrid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Services.EventBus
{
    public static class EventGridServices
    {
        public static EventGridPublisherClient CreateClient(string endpointUrl, string eventKeyAccessKey)
        {
            return new EventGridPublisherClient(new Uri (endpointUrl),new AzureKeyCredential(eventKeyAccessKey));
        }
    }
}
