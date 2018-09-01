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
    public class MenuServices : BaseService<MenuRepository>, IService<DtoMenu>
    {
        public ServiceResult<DtoMenu> Add(DtoMenu item)
        {
            try
            {
                var result = Repository.Create(new Menu()
                {
                    Typeid = (byte)item.TypeOfMenu,
                    RestaurantName = item.RestaurantName
                });
                return new ServiceResult<DtoMenu>()
                {
                    Item = new DtoMenu(result),
                    Success = true
                };
            }
            catch(Exception ex)
            {
                return new ServiceResult<DtoMenu>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMenu> Edit(DtoMenu item)
        {
            throw new NotImplementedException();
        }

        public ServiceResult<DtoMenu> Load(int id)
        {
            //try
            //{
            //    var result = Repository.GetById(id);
            //    var resultOne = new DtoMenu();
            //    result.ForEach(m => resultList.Add(new DtoMenu(m)));
            //    return new ServiceResult<DtoMenu>()
            //    {
            //        Item = resultOne,
            //        Success = true
            //    };
            //}
            //catch (Exception ex)
            //{
            //    return new ServiceResult<DtoMenu>()
            //    {
            //        Success = false,
            //        Exception = ex,
            //        ErrorMessage = ex.Message
            //    };
            //}
            throw new NotImplementedException();

        }

        public ServiceResult<DtoMenu> LoadAll()
        {
            try
            {
                var result = Repository.GetAll().ToList();
                var resultList = new List<DtoMenu>();
                result.ForEach(m => resultList.Add(new DtoMenu(m)));
                return new ServiceResult<DtoMenu>()
                {
                    ListItems = resultList,
                    Success = true
                };
            }
            catch (Exception ex)
            {
                return new ServiceResult<DtoMenu>()
                {
                    Success = false,
                    Exception = ex,
                    ErrorMessage = ex.Message
                };
            }
        }

        public ServiceResult<DtoMenu> Remove(DtoMenu item)
        {
            throw new NotImplementedException();
        }
    }
}
