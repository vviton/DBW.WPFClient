using DBW.WPFClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBW.WPFClient.Services
{
    public interface IAreaService
    {
         Task<List<Area>> GetAreasAsync();
    }
}
