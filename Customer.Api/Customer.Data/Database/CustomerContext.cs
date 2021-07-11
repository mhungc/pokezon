﻿using Pokezon.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokezon.CustomerApi.Data.Database
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customer { get; set; }

        public CustomerContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("ProductVersion", "2.2.6-servicing-10079");

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.Property(e => e.Id).HasDefaultValueSql("(newid())");

                entity.Property(e => e.Birthday).HasColumnType("date");

                entity.Property(e => e.FirstName).IsRequired();

                entity.Property(e => e.LastName).IsRequired();
            });

            modelBuilder.Entity<Customer>().HasData(
               new Customer
               {
                   Id = Guid.Parse("9f35b48d-cb87-4783-bfdb-21e36012930a"),
                   FirstName = "Wolfgang",
                   LastName = "Ofner",
                   Birthday = new DateTime(1989, 11, 23),
                   Age = 30,
                   Total = 60
               },
                new Customer
                {
                    Id = Guid.Parse("654b7573-9501-436a-ad36-94c5696ac28f"),
                    FirstName = "Darth",
                    LastName = "Vader",
                    Birthday = new DateTime(1977, 05, 25),
                    Age = 43,
                    Total = 6
                },
                new Customer
                {
                    Id = Guid.Parse("971316e1-4966-4426-b1ea-a36c9dde1066"),
                    FirstName = "Son",
                    LastName = "Goku",
                    Birthday = new DateTime(1937, 04, 16),
                    Age = 83,
                    Total = 6
                }
                );
        }
    }
}
