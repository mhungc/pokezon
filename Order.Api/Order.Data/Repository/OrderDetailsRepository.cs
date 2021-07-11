using Pokezon.OrderApi.Data.Database;
using Pokezon.OrderApi.Data.Repository;
using Pokezon.OrderApi.Domain;
using Popkezon.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.Data.Repository
{
    public class OrderDetailsRepository : Repository<OrderDetail>, IOrderDetailsRepository
    {
        public OrderDetailsRepository(OrderContext orderContext) : base(orderContext)
        {
        }

        public async Task<List<OrderDetail>> AddRangeAsync(List<OrderDetail> orderDetails)
        {
            await OrderContext.AddRangeAsync(orderDetails);
            await OrderContext.SaveChangesAsync();
            return orderDetails;

        }
    }   
}
