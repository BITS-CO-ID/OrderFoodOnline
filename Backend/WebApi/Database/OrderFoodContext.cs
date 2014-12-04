using System.Data.Entity;
using OrderFoodOnline.WebApi.Models;

namespace OrderFoodOnline.WebApi.Database
{
    public class OrderFoodContext : DbContext
    {
        public DbSet<DeliveryService> DeliveryServices { get; set; }
        public DbSet<Meal> Meals { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<Account> Accounts { get; set; }

        public OrderFoodContext()
            : base("OrderFoodDb")
        {
        }
    }
}