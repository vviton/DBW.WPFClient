using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBW.WPFClient.Models
{
    public class Area
    {
        [JsonProperty("id")]
        public int Id { get; set; }
        [JsonProperty("nazwa")]
        public string Name { get; set; }
        [JsonProperty("id-nadrzedny-element")]
        public int ParentId { get; set; }
        [JsonProperty("id-poziom")]
        public int LevelId { get; set; }
        [JsonProperty("nazwa-poziom")]
        public string LevelName { get; set; }
        [JsonProperty("czy-zmienne")]
        public bool Changeable { get; set; }
        public Area() { }

        public Area(int id, string name, int parentId, int levelId, string levelName, bool changeable)
        {
            Id = id;
            Name = name;
            ParentId = parentId;
            LevelId = levelId;
            LevelName = levelName;
            Changeable = changeable;
        }
    }
}
