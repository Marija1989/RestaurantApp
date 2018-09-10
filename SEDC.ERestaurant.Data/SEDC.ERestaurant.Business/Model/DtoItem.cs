using SEDC.ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Business.Model
{
    public class DtoItem
    {
  
     
        public int Id { get; set; }
       
        public string Name { get; set; }
       
        public bool Availability { get; set; }
        
        public double Price { get; set; }
        
        public string Contents { get; set; }
        
        public string Description { get; set; }
        
        public int CategoryId { get; set; }


        public DtoItem()
        {

        }

        public DtoItem(Item item)
        {
            Id = item.Id;
            Name = item.Name;
            Availability = item.Availability;
            Price = item.Price;
            Contents = item.Contents;
            Description = item.Description;
            CategoryId = item.CategoryId;

        }
    }
}
