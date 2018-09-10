using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Data.Model
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
        public  double? TotalPrice => Items?.Sum(loi => loi.Quantity * loi.Item.Price);
        public  int? TotalQuantity => Items?.Sum(i => i.Quantity);
        [Required]
        public DateTime DateCreated { get; set; }
        public  byte StatusOfOrder { get; set; }
        public string Comment { get; set; }
        [Required]
        [MaxLength(3)]
        public string Table { get; set; }

        public List<OrderItem> Items { get; set; }



    }
}
