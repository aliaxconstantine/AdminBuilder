using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Service.EventModelDTO
{
    public static class AppConstants
    {
        //表示行数据更新key
        public readonly static string ColumnKey = "Column";
        //表示表数据更新key
        public readonly static string ViewKey = "View";
        //表示新建连接
        public readonly static string DataBaseKey = "DataBase";
        //表示修改字体
        public readonly static string FontKey = "Font";
        public readonly static string PlaceholderManyList = "%%";
        public readonly static string PlaceholderOriginalTableName = "原表名";
        public readonly static string PlaceholderTableName = "表名";
        public readonly static string PlaceholderTableNameClass = "表名类";
        public readonly static string OutputErrorText = "输出错误，请查看是否创建相应数据库映射";
        public readonly static string PlaceholderPropertyName = "属性名称";
        public readonly static string PlaceholderOriginalPropertyName = "原属性名";
        public readonly static string PlaceholderPropertyNameClass = "属性名称类";
        public readonly static string PlaceholderPropertyType = "属性类型";
        public readonly static string PlaceholderDefaultValue = "默认值";

    }
}
