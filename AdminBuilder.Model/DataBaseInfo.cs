using AdminBuilder.Utils.AttributeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Model
{
    /// <summary>
    /// 数据库信息
    /// </summary>
    public class DataBaseInfo
    {
        [Model("数据库名", "Name")]
        public string Name { get; set; } = string.Empty;
        [Model("版本号", "Version")]
        public string Version { get; set; } = string.Empty;
        [Model("表名集合", "TableNames")]
        public List<string> TableNames { get; set; } = new List<string>();
        public DataBaseInfo(string name, string version, List<string> tableNames)
        {
            Name = name;
            Version = version;
            TableNames = tableNames;
        }
        public DataBaseInfo() { }
    }
}
