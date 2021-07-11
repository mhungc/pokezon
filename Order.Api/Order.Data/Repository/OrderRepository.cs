using Microsoft.EntityFrameworkCore;
using Pokezon.OrderApi.Data.Database;
using Pokezon.OrderApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Data.Repository
{
    public class OrderRepository : Repository<Order>, IOrderRepository
    {
        public OrderRepository(OrderContext orderContext) : base(orderContext)
        {
        }

        public async Task<Order> GetOrderByIdAsync(Guid orderId, CancellationToken cancelltationToken)
        {
            return await OrderContext.Order.FirstOrDefaultAsync(x => x.OrderId == orderId, cancelltationToken);
        }
    }
}
