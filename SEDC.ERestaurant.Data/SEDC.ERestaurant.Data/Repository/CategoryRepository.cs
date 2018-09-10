using SEDC.ERestaurant.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Data.Repository
{
    public class CategoryRepository : BaseRepository, IRepository<Category>
    {
        public Category Create(Category type)
        {
            DbContext.Categories.Add(type);
            DbContext.SaveChanges();
            return type;
        }

        public void Delete(Category item)
        {
            var itemOne = DbContext.Categories.Single(m => m.Id == item.Id);
            DbContext.Categories.Remove(itemOne);
            DbContext.SaveChanges();
        }

        public IEnumerable<Category> GetAll()
        {
            var Menues = DbContext.Categories.ToList();
            return Menues;
        }

        public Category GetById(int id)
        {
            return DbContext.Categories.SingleOrDefault(m => m.Id == id);
        }

        public void Update(Category type)
        {
            var dbItem = DbContext.Categories.Single(m => m.Id == type.Id);
          
            dbItem.MenuId = type.MenuId;
            dbItem.Name = type.Name;
            DbContext.Entry<Category>(dbItem).State = System.Data.Entity.EntityState.Modified;
            DbContext.SaveChanges();
        }
    }
}
