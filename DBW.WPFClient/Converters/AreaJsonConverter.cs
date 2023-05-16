using DBW.WPFClient.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBW.WPFClient.Converters
{
    public class AreaJsonConverter : IAreaConverter
    {
        public Area ConvertStringToArea(string json)
        {
            return JsonConvert.DeserializeObject<Area>(json);
        }

        public List<Area> ConvertToListOfAreas(string json)
        {
            return JsonConvert.DeserializeObject<List<Area>>(json);
        }
    }
}
