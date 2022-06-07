﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Store.Data.EF
{
    public class StoreDbContext : DbContext
    {
        public DbSet<BookDto> Books { get; set; }

        public DbSet<OrderDto> Orders { get; set; }

        public DbSet<OrderItemDto> OrderItems { get; set; }

        public StoreDbContext(DbContextOptions<StoreDbContext> options)
            : base(options)
        { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            BuildBooks(modelBuilder);
            BuildOrders(modelBuilder);
            BuildOrderItems(modelBuilder);
        }

        private static void BuildOrderItems(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderItemDto>(action =>
            {
                action.Property(dto => dto.Price)
                      .HasColumnType("money");

                action.HasOne(dto => dto.Order)
                      .WithMany(dto => dto.Items)
                      .IsRequired();
            });
        }

        private static void BuildOrders(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<OrderDto>(action =>
            {
                action.Property(dto => dto.CellPhone)
                      .HasMaxLength(20);

                action.Property(dto => dto.DeliveryUniqueCode)
                      .HasMaxLength(40);

                action.Property(dto => dto.DeliveryPrice)
                      .HasColumnType("money");

                action.Property(dto => dto.PaymentServiceName)
                      .HasMaxLength(40);

                action.Property(dto => dto.DeliveryParameters)
                      .HasConversion(
                          value => JsonConvert.SerializeObject(value),
                          value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
                      .Metadata.SetValueComparer(DictionaryComparer);

                action.Property(dto => dto.PaymentParameters)
                      .HasConversion(
                          value => JsonConvert.SerializeObject(value),
                          value => JsonConvert.DeserializeObject<Dictionary<string, string>>(value))
                      .Metadata.SetValueComparer(DictionaryComparer);

            });       
        }

        private static readonly ValueComparer DictionaryComparer =
                     new ValueComparer<Dictionary<string, string>>(
                         (dictionary1, dictionary2) => dictionary1.SequenceEqual(dictionary2),
                         dictionary => dictionary.Aggregate(
                             0,
                             (a, p) => HashCode.Combine(HashCode.Combine(a, p.Key.GetHashCode(), p.Value.GetHashCode())
                                 )
                             )
                         );

        private static void BuildBooks(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookDto>(action =>
            {
                action.Property(dto => dto.Isbn)
                      .HasMaxLength(17)
                      .IsRequired();

                action.Property(dto => dto.Title)
                      .IsRequired();

                action.Property(dto => dto.Price)
                      .HasColumnType("money");

                action.HasData(
                    new BookDto
                    {
                        Id = 1,
                        Isbn = "ISBN0201038013",
                        Author = "D. Knuth",
                        Title = "Art of Programming, Vol. 1",
                        Description = "This volume begins with basic programming concepts",
                        Price = 690m,
                    },
                    new BookDto
                    {
                        Id = 2,
                        Isbn = "ISBN0201454816",
                        Author = "M. Fowler",
                        Title = "Refactoring",
                        Description = "As the application of object technology--",
                        Price = 450m,
                    },
                    new BookDto
                    {
                        Id = 3,
                        Isbn = "ISBN0131101633",
                        Author = "B. W. Kernighan, D. M. Ritchie",
                        Title = "C Programminh Language",
                        Description = "Known as the bible of C, this classic bestseller",
                        Price = 350m,
                    });
            });
        }
    }
}

