using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using Test.Entities;

namespace Test.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
        public DbSet<Product> Products { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<BuyOrder> BuyOrders { get; set; }
        public DbSet<BuyOrderDetail> BuyOrderDetails { get; set; }
    }
}
