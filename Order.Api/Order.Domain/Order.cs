
using Pokezon.OrderApi.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Domain
{
    public class Order
    {
        public Guid OrderId { get; set; }
        public OrderStatus Status { get; set; }
        public OrderPayment PaymentType { get; set; }
        public Guid CustomerId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public DateTime CreatedAt { get; set; }
        public decimal Total { get; set; }
    }


}
