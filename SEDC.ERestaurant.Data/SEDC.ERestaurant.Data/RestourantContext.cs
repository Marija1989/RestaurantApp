using SEDC.ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Data
{
    public class RestourantContext : DbContext
    {
        public DbSet<Menu> Menues { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Item> Items { get; set; }

        public RestourantContext() : base("name=RestaurantConnection")
        {

        }
    }
}
