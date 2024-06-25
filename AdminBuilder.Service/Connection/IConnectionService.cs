using AdminBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Service.Connection
{
    public interface IConnectionService
    {
        bool CreateDataBase(string name, string text, string type);
        List<ConnectionModelInfo> GetAllConnection(int pageNum);
        ConnectionModelInfo GetConnection(string databaseName);
        bool RemoveConnection(ConnectionModelInfo name);
        bool UpdateConnection(ConnectionModelInfo info);
    }
}
