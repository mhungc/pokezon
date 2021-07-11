using MediatR;
using Pokezon.OrderApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.Services.Query
{
    public class GetOrdersQuery : IRequest<List<Order>>
    {
    }
}
