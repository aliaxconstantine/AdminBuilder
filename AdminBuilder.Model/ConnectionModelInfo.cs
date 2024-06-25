using AdminBuilder.Utils.AttributeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Model
{
    public class ConnectionModelInfo
    {
        [Model("连接Id", "ConnectionId", false)]
        public int ConnectionId { get; set; } = 0;
        [Model("连接名", "Name")]
        public string Name { get; set; } = string.Empty;
        [Model("连接字符串", "ConnectionString")]
        public string ConnectionString { get; set; } = string.Empty;
        [Model("连接类型", "ConnectionType", IsComboBox = true, Options = new string[] {"MySql","SqlServer"})]
        public string ConnectionType { get; set; } = string.Empty;
        [Model("连接命名规范", "ConnectionNameType", true, IsComboBox = true, Options = new string[] { "小写", "大写", "下划线", })]
        public string ConnectionNameType { get; set; } = string.Empty;

        [Model("连接备注", "Description")]
        public string Description { get; set; } = string.Empty;

        [Model("连接库名", "DataBaseInfoName",false)]
        public string DataBaseInfoName { get; set; } = string.Empty;

        public ConnectionModelInfo() { }
        public ConnectionModelInfo(string name, string connectionString, string connectionType, string description)
        {
            Name = name;
            ConnectionString = connectionString;
            ConnectionType = connectionType;
            Description = description;
        }
    }
}
