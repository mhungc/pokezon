using Pokezon.OrderApi.Domain;
using Pokezon.OrderApi.Domain.Types;
using System;
using System.Collections.Generic;

namespace Pokezon.Api.Controllers
{
    public class OrderModel
    {
        public Guid OrderId { get; set; }
        public OrderPayment PaymentType { get; set; }
        public Guid CustomerId { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
        public decimal Total { get; set; }
    }
}