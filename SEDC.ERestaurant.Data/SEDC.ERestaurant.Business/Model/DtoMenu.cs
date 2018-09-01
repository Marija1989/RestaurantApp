using SEDC.ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Business.Model
{
    public class DtoMenu
    {
        public DtoMenu()
        {

        }

        public DtoMenu(Menu menu)
        {
            Id = menu.Id;
            TypeOfMenu = (MenuType)menu.Typeid;
        }

        public int Id { get; set; }

        public MenuType TypeOfMenu { get; set; }

        public string RestaurantName { get; set; }
    }
}
