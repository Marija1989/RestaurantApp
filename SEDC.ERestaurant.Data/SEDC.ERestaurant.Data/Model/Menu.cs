using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Data.Model
{
    public class Menu
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public byte Typeid { get; set; }
        //public Type TypeOfMenu { get; set; }
        [Required]
        [MaxLength(200)]
        public string RestaurantName{ get; set; }
        public List<Category> Categories { get; set; }
    }
}
