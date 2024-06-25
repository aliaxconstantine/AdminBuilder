using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Utils.DataBaseConfig
{
    public static class DataBaseTool
    {
        public static DbType ConvertDbType(string type)
        {
            DbType typeBb = DbType.MySql; // 默认未知类型或者可以设置默认值

            switch (type)
            {
                case "MySql":
                    typeBb = DbType.MySql;
                    break;
                case "SqlServer":
                    typeBb = DbType.SqlServer;
                    break;
             
                default:
                    throw new ArgumentException("Unsupported database type: " + type);
            }

            return typeBb;
        }
    }
}
