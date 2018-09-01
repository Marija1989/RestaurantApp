using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Data.Model
{
    public enum MenuType :byte
    {
        Undefined = 0,
        Meals = 1,
        Drinks = 2,
        Wines = 3
    }
}
