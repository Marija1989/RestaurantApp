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
    public class CategoryService : BaseService<CategoryRepository>, IService<DtoCategory>
    {
        //private readonly MenuRepository _menuRepository;
        public CategoryService()
        {
            //_menuRepository = new MenuRepository();
        }
        public ServiceResult<DtoCategory> Add(DtoCategory type)
        {
            
            try
            {

                var resultMenu = /*_menuRepository.GetById(type.MenuId);*/ Repository.DbContext.Menues.Any(m => m.Id == type.MenuId);

                if (resultMenu)
                {
                    var result = Repository.Create(new Category()
                    {
                        Id = 0,
                        Name = type.CategoryName,
                        MenuId = type.MenuId

                    });
                 var resultFinal = new  ServiceResult<DtoCategory>()
                    {
                        Item = new DtoCategory(result),
                        Success = true
                    };
                    return resultFinal;
                }
                else
                {
                    return new ServiceResult<DtoCategory>()
                    {
                       Success = false,
                       

                    };
                }
   
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoCategory>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoCategory> Edit(DtoCategory type)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoCategory> Load(int id)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoCategory> LoadAll()
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoCategory> Remove(DtoCategory item)
        {
            throw new NotImplementedException();
        }
    }
}
