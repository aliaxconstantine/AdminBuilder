using AdminBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Service.DataBase
{
    public interface IDataBaseService
    {
        DataBaseInfo GetDataBaseInfo(string name);
        List<DataBaseInfo> GetALllDataBaseInfo();
    }
}
