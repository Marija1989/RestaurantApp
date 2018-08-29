using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Data.Model
{
    public class Menu
    {
        public int Id { get; set; }
        public Type TypeOfMenu { get; set; }
        public string RestaurantName{ get; set; }
        public List<Category> Categories { get; set; }
    }
}
