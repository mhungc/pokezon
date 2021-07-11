using Microsoft.EntityFrameworkCore;
using Pokezon.Domain;
using Pokezon.OrderApi.Domain;
using Pokezon.OrderApi.Domain.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.OrderApi.Data.Database
{
    public class OrderContext : DbContext
    {
        public DbSet<Order> Order { get; set; }
        public DbSet<OrderDetail> OrderDetail { get; set; }
        public DbSet<Pokemon> Pokemon { get; set; }

        public OrderContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var oder1 = new Order
            {
                OrderId = Guid.Parse("80dc2e79-ed62-4cfe-8fc6-ce861860873f"),
                CustomerId = Guid.Parse("971316e1-4966-4426-b1ea-a36c9dde1066"),
                Total = 100,
                CreatedAt = DateTime.Now,
                PaymentType = OrderPayment.CreditCard,
            };
            modelBuilder.Entity<Order>().HasData(oder1);

            modelBuilder.Entity<OrderDetail>().HasData(
                new OrderDetail
                {
                    OrderDetailId = Guid.Parse("bda2ca08-0bb3-4142-9d90-72216507caa2"),
                    Quantity = 3,
                    OrderId = Guid.Parse("80dc2e79-ed62-4cfe-8fc6-ce861860873f"),
                    Total = 190,
                    UnitPrice = 83,
                    ProductId = Guid.NewGuid()
                });

            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Order>(entity =>
            {
                entity.Property(e => e.OrderId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.Property(e => e.OrderDetailId).HasDefaultValueSql("(newid())");
            });

            modelBuilder.Entity<Pokemon>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");
            });
        }
    }
}
