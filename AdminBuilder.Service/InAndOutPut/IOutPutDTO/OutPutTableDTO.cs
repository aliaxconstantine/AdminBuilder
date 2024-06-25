using AdminBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Service.InAndOutPut.IOutPutDTO
{
    public class OutPutTableDTO
    {
        public string TableName;
        public List<ColumnInfo> calumnious;
        public string DataBaseType;
        //原本表名命名规则
        public StringType StringType;
        public string TypeClass;
        public OutPutTableDTO() { }
    }
}
