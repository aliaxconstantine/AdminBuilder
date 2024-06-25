using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Utils.ConfigManager
{
    public class AdminAppConfig
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public bool IsList { get; set; }
        public AdminAppConfig(string name, string type , bool isList = false)
        {
            Name = name;
            Type = type;
            IsList = isList;
        }
    }
}
