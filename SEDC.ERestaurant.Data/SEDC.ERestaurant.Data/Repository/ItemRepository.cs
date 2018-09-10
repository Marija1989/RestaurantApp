using SEDC.ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;  
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Data.Repository
{
    public class ItemRepository : BaseRepository, IRepository<Item>
    {
        public Item Create(Item item)
        {
            DbContext.Items.Add(item);
            DbContext.SaveChanges();
            return item;
        }

        public void Delete(Item item)
        {
            var itemOne = DbContext.Items.Single(m => m.Id == item.Id);
            DbContext.Items.Remove(itemOne);
            DbContext.SaveChanges();
        }

        public IEnumerable<Item> GetAll()
        {
            var Items = DbContext.Items.ToList();
            return Items;
        }

        public Item GetById(int id)
        {
            return DbContext.Items.SingleOrDefault(m => m.Id == id);
        }

        public void Update(Item item)
        {
            var dbItem = DbContext.Items.Single(m => m.Id == item.Id);
            dbItem.Name = item.Name;
            dbItem.Availability = item.Availability;
            dbItem.Price = item.Price;
            dbItem.Contents = item.Contents;
            dbItem.CategoryId = item.CategoryId;
            dbItem.Description = item.Description;

            DbContext.Entry<Item>(dbItem).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
