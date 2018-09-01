using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Business.Service
{
    public interface IService<T>
    {
        ServiceResult<T> LoadAll();
        ServiceResult<T> Load(int id);
        ServiceResult<T> Add(T type);
        ServiceResult<T> Edit(T type);
        ServiceResult<T> Remove(T item);
    }
}
