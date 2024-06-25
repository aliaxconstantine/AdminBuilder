using AdminBuilder.Model;
using AdminBuilder.Service.Connection;
using AdminBuilder.Utils.ConfigManager;
using AdminBuilder.Utils.DataBaseConfig;
using System.Collections.Generic;

namespace AdminBuilder.Service.EventModelDTO
{

    public static class ConnectionConfig
    {
        public static void InitConnectionConfig()
        {
            const string configKey = nameof(ConnectionModelInfo);
            ConfigurationManager.InitConfig += InitConnection;
            var config = ConfigurationManager.GetConfig(new AdminAppConfig(configKey, configKey), new List<ConnectionModelInfo>());
            if (config == null)
            {
                return;
            }
            config.ForEach(connection =>
            {
                DataBaseConstants.CreateConnecting(connection.Name, connection.ConnectionString, connection.ConnectionType);
                ConnectionService.SendFreshMessage(connection.Name);
            });

            void InitConnection()
            {
                ConfigurationManager.InitAddConfig(new AdminAppConfig(configKey, configKey,true));
            }
        }

    }
}
