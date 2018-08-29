using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Data.Model
{
    public class Order
    {
        public int Id { get; set; }
        private float TotalPrice { get; }
        private int TotalQuantity { get; }
        public DateTime DateCreated { get; set; }
        public  Status StatusOfOrder { get; set; }
        public string Comment { get; set; }
        public int Table { get; set; }

        public List<Item> Items { get; set; }

    }
}
