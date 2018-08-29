using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Data.Model
{
    public class Item
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool Availability { get; set; }
        public float Price { get; set; }
        public string Contents { get; set; }
        public string Description { get; set; }
        public int CategoryId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
