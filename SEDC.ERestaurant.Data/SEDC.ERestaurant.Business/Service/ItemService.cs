using SEDC.ERestaurant.Business.Model;
using SEDC.ERestaurant.Data.Model;
using SEDC.ERestaurant.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Business.Service
{
    public class ItemService : BaseService<ItemRepository>, IService<DtoItem>
    {
        public ServiceResult<DtoItem> Add(DtoItem item)
        {
            var categoryExist = Repository.DbContext.Categories.Any(i => i.Id == item.CategoryId);
            if(categoryExist)
            {
                var result = Repository.Create(new Item()
                {
                    Id = 0,
                    Name = item.Name,
                    Availability = item.Availability,
                    Price = item.Price,
                    Contents = item.Contents,
                    Description = item.Description,
                    CategoryId = item.CategoryId,
            });
               return new ServiceResult<DtoItem>()
                {
                    Item = new DtoItem(result),
                    Success = true
                };
              
            }
            else
            {
                return new ServiceResult<DtoItem>()
                {
                    Success = false,
                    ErrorMessage = "Cannot insert the item!",
                };
            }
        }

        public ServiceResult<DtoItem> Edit(DtoItem type)
        {
            try
            {
                var categoryExist = Repository.DbContext.Categories.Any(i => i.Id == type.CategoryId);
                if (categoryExist)
                {
                    var itemOne = Repository.GetById(type.Id);
                    itemOne.Name = type.Name;
                    itemOne.Price = type.Price;
                    itemOne.Description = type.Description;
                    itemOne.Availability = type.Availability;
                    itemOne.Contents = type.Contents;
                    itemOne.CategoryId = type.CategoryId;
                    Repository.Update(itemOne);
                }
                return new ServiceResult<DtoItem>()
                {
                   
                    Success = true
                };
            }
            catch(Exception ex)
            {
                return new ServiceResult<DtoItem>()
                {
                    Success = false,
                    ErrorMessage = "Cannot insert the item!",
                };
            }
        }

        public ServiceResult<DtoItem> Load(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoItem> LoadAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoItem> Remove(DtoItem item)
        {
            throw new NotImplementedException();
        }
    }
}
