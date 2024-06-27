using AdminBuilder.Utils.AttributeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Model
{
    public class TableMapper
    {
        [Model("映射id", "TableMapperId",false)]
        public int TableMapperId { get; set; } = 0;
        [Model("数据库类别", "TableName",IsComboBox = true , Options = new string[] {"MySql","SqlServer"})]
        public string TableName { get; set; } = string.Empty;
        [Model("输入类型", "inTableName")]
        public string inTableName { get; set; } = string.Empty;
        [Model("输出类型", "outTableName")]
        public string outTableName { get; set; } = string.Empty;
        [Model("语言类型", "ClassType", isComboBox: true, new string[] { "java", "dotnet", "python" })]
        public string ClassType { get; set; } = string.Empty;

        [Model("默认值", "DefaultValue")]
        public string DefaultValue { get; set; } = string.Empty;
        public TableMapper() { }
    }
}
