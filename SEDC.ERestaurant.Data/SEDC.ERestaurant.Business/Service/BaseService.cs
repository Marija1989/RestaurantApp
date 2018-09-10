using SEDC.ERestaurant.Data;
using SEDC.ERestaurant.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SEDC.ERestaurant.Business.Service
{
    public class BaseService<T> : IDisposable where T : BaseRepository
    {

        private T _repository;
        public T Repository  => _repository;
        protected RestourantContext DbContext => _repository.DbContext;
        public BaseService()
        {
            _repository = Activator.CreateInstance<T>();
        }
        public void Dispose()
        {
            _repository.Dispose();
        }
    }
}
