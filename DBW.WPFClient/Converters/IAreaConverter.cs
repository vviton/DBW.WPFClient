using DBW.WPFClient.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBW.WPFClient.Converters
{
    public interface IAreaConverter
    {
        public Area ConvertStringToArea(string areaString);
        public List<Area> ConvertToListOfAreas(string areaListString);
    }
}
