using AdminBuilder.Utils.AttributeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Model
{
    /// <summary>
    /// 数据库表信息
    /// </summary>
    public class TableBaseInfo
    {
        // 表的名称
        [Model("表名", "TableName")]
        public string TableName { get; set; } = string.Empty;

        [Model("曾用名", "OldName", false)]
        public string OldName { get; set; } = string.Empty;

        [Model("备注", "Desc")]
        public string Desc { get; set; } = string.Empty;

        public TableBaseInfo(string tableName)
        {
            TableName = tableName;
        }
    }
}
