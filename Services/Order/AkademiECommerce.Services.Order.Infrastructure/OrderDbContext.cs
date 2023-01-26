using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AkademiECommerce.Services.Order.Infrastructure
{
    public class OrderDbContext:DbContext
    {
        public const string default_schema = "ordering";

        public OrderDbContext(DbContextOptions<OrderDbContext>options):base(options)
        {

        }

        public DbSet<Domain.OrderAggregate.Order> Orders { get; set; }
        public DbSet<Domain.OrderAggregate.OrderItem> OrderItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Domain.OrderAggregate.OrderItem>().ToTable("OrderItems", default_schema);
            modelBuilder.Entity<Domain.OrderAggregate.Order>().ToTable("Orders", default_schema);
            modelBuilder.Entity<Domain.OrderAggregate.OrderItem>().Property(x => x.Price).HasColumnType("decimal(18,2)");
            modelBuilder.Entity<Domain.OrderAggregate.OrderItem>().Property(x => x.ProductName).HasColumnType("nvarchar(200)");
            modelBuilder.Entity<Domain.OrderAggregate.Order>().OwnsOne(o => o.Address).WithOwner();
            base.OnModelCreating(modelBuilder);
        }
    }
}
