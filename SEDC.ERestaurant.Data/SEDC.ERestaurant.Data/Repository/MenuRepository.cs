using SEDC.ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Data.Repository  
{
    public class MenuRepository : BaseRepository, IRepository<Menu>
    {
        public Menu Create(Menu item)
        {
            DbContext.Menues.Add(item);
            DbContext.SaveChanges();
            return item;
        }

        public void Delete(Menu item)
        {
            var itemOne = DbContext.Menues.Single(m => m.Id == item.Id);
            DbContext.Menues.Remove(itemOne);
            DbContext.SaveChanges();

        }

        public IEnumerable<Menu> GetAll()
        {
            var Menues = DbContext.Menues.ToList();
            return Menues;
        }

        public Menu GetById(int id)
        {
            return DbContext.Menues.SingleOrDefault(m => m.Id == id);
        }

        public void Update(Menu item)
        {
            var dbItem = DbContext.Menues.Single(m => m.Id == item.Id);
            dbItem.Typeid = item.Typeid;
            dbItem.RestaurantName = item.RestaurantName;
            DbContext.Entry<Menu>(dbItem).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
