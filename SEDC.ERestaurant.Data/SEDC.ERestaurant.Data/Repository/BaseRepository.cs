using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace SEDC.ERestaurant.Data.Repository
{
    public class BaseRepository : IDisposable
    {
        private RestourantContext _context;
        public RestourantContext DbContext => _context;

        public BaseRepository()
        {
            _context = new RestourantContext();
        }
       

        public void Dispose()
        {
            _context?.Dispose();
        }
    }
}
