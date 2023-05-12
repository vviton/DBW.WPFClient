using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DBW.WPFClient.Models
{
    public class Area
    {
        public int Id {  get; set; }
        public string Name { get; set; }
        public int ParentId { get; set; }
        public int LevelId { get; set; }
        public string LevelName { get; set; }
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
