using Pokezon.OrderApi.Data.Repository;
using Pokezon.OrderApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Popkezon.Data.Repository
{
    public interface IOrderDetailsRepository : IRepository<OrderDetail>
    {
        public Task<List<OrderDetail>> AddRangeAsync(List<OrderDetail> orderDetails);
    }
}
