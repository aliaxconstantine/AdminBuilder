using AdminBuilder.Model;
using AdminBuilder.Service.EventModelDTO;
using AdminBuilder.Utils.ConfigManager;
using AdminBuilder.Utils.ControlEvent;
using AdminBuilder.Utils.DataBaseConfig;
using Newtonsoft.Json;
using Sunny.UI;
using System.Collections.Generic;
using System.Linq;

namespace AdminBuilder.Service.Connection
{
    public class ConnectionService : IConnectionService
    {
        const string configKey = nameof(ConnectionModelInfo);
        public bool CreateDataBase(string name, string text, string type)
        {
            var connectionConfigData = ConfigurationManager.GetConfig(new AdminAppConfig(configKey,configKey), new List<ConnectionModelInfo>());
            connectionConfigData.Add(new ConnectionModelInfo()
            {
                ConnectionId = connectionConfigData.Count,
                Name = name,
                ConnectionType = type,
                ConnectionString = text,
            }) ;
            var result = DataBaseConstants.CreateConnecting(name, text, type).Ado.IsValidConnection();
            if (!result)
            {
                return false;
            }
            SendFreshMessage(text);
            return true;
        }

        public static void SendFreshMessage(string text)
        {
            //消息通知更新数据表
            var ew = new DataRefreshEventArgs
            {
                Data = JsonConvert.SerializeObject(new DataViewEventArgs()
                {
                    DataBaseName = text,
                    FreshType = AppConstants.DataBaseKey
                })
            };
            DataEventManager.Instance.Dispatch(nameof(DataViewEventArgs), ew);
        }

        public List<ConnectionModelInfo> GetAllConnection(int pageNum)
        {
            var connectionConfigData = ConfigurationManager.GetConfig(new AdminAppConfig(configKey, configKey), new List<ConnectionModelInfo>());
            return connectionConfigData.Skip(DataBaseConstants.PageIndex * (pageNum - 1)).Take(DataBaseConstants.PageIndex).ToList();
        }

        public bool RemoveConnection(ConnectionModelInfo info)
        {
            var connectionConfigData = ConfigurationManager.GetConfig(new AdminAppConfig(configKey, configKey), new List<ConnectionModelInfo>());
            connectionConfigData.Remove(connectionConfigData.Find(i => i.ConnectionId == info.ConnectionId));
            bool result = DataBaseConstants.sqlSugarClients.TryRemove(info.Name, out var conn);
            //发送消息通知
            SendFreshMessage(info.Name);
            return result;
        }

        public bool UpdateConnection(ConnectionModelInfo info)
        {
            var connectionConfigData = ConfigurationManager.GetConfig(new AdminAppConfig(configKey, configKey), new List<ConnectionModelInfo>());
            //先找到旧name
            var oldConnection = connectionConfigData.Find(t => t.ConnectionId == info.ConnectionId);
            if (oldConnection == null)
            {
               return false;
            }
            //根据旧name删除
            bool result = DataBaseConstants.sqlSugarClients.TryRemove(oldConnection.Name, out var conn);
            DataBaseConstants.CreateConnecting(info.Name, info.ConnectionString, info.ConnectionType);
            connectionConfigData.Remove(oldConnection);
            connectionConfigData.Add(info);
            //发送消息通知
            SendFreshMessage(info.Name);    
            return result;
        }

        public ConnectionModelInfo GetConnection(string databaseName)
        {
            var connectionConfigData = ConfigurationManager.GetConfig(new AdminAppConfig(configKey, configKey), new List<ConnectionModelInfo>());
            return connectionConfigData.Find(t=> t.Name == databaseName);
        }
    }
}
