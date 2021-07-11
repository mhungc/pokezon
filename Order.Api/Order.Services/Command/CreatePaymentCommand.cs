using MediatR;
using Pokezon.OrderApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Services.Command
{
    public class CreatePaymentCommand: IRequest<Order>
    {
        public Order Order { get; set; }

    }
}
