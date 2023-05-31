using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBW.WPFClient.Repository
{
    public interface IRepository<T>
    {
         Task<List<T>> GetAllAsync();
    }
}
