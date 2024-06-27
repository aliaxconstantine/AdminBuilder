using AdminBuilder.Utils.AttributeUtils;
using AdminBuilder.Utils.DataBaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Model
{
    /// <summary>
    /// 数据库列
    /// </summary>
    public class ColumnInfo
    {

        // 列名
        [Model("列名", "ColumnName")]
        public string ColumnName { get; set; } = string.Empty;

        [Model("曾用名", "OldName", false)]
        public string OldName { get; set; } = string.Empty;

        // 列数据类型
        [Model("列数据类型", "DataType", true, new string[] { "int", "varchar", "char", "text", "datetime", "float", "double" })]
        public string DataType { get; set; } = string.Empty;

        // 是否允许为 null
        [Model("是否为null", "IsNullable")]
        public bool IsNullable { get; set; } = false;

        //是否为主键
        [Model("是否为主键", "isMain")]
        public bool isMain { get; set; } = false;

        // 列描述
        [Model("描述", "Description")]
        public string Description { get; set; } = string.Empty;

        public ColumnInfo() {  }
        public ColumnInfo(string columnName, string dataType, bool isNullable, bool isMain)
        {
            this.ColumnName = columnName;
            this.DataType = dataType;
            this.IsNullable = isNullable;
            this.isMain = isMain;
        }
    }
}
