using NLog;
using SqlSugar;
using System;
using System.Collections.Concurrent;
using System.Windows.Forms;

namespace AdminBuilder.Utils.DataBaseConfig
{
    public static class DataBaseConstants
    {
        private static Logger logger = LogManager.GetCurrentClassLogger();
        public static readonly ConcurrentDictionary<string, SqlSugarClient> sqlSugarClients = new ConcurrentDictionary<string, SqlSugarClient>();
        public static readonly int PageIndex = 10;
        public static readonly string[] sqlType = new string[] { "int", "varchar", "char", "text", "datetime", "float", "double" };


        public static SqlSugarClient CreateConnecting(string name, string connectionString, string dbType)
        {
            var sqlClient = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = DataBaseTool.ConvertDbType(dbType),
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            if (!sqlClient.Ado.IsValidConnection())
            {
                throw new Exception("错误的连接字符串");
            }
            sqlClient.Aop.OnLogExecuted = (sql, per) =>
            {
                logger.Info("\r\n");
                logger.Info($"{DateTime.Now:yyyyMMdd：HH:mm:ss} sql:{sql}");
            };
            sqlSugarClients.TryAdd(name, sqlClient);
            return sqlClient;
        }

        public static SqlSugarClient GetSqlSugarClient(string name)
        {
            sqlSugarClients.TryGetValue(name, out var sqlClient);
            return sqlClient;
        }


        public static bool TestClientIsOneBase(string type,string connectionString)
        {
            var db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = connectionString,
                DbType = DataBaseTool.ConvertDbType(type),
                IsAutoCloseConnection = true,
                InitKeyType = InitKeyType.Attribute
            });
            try 
            {
                return db.Ado.IsValidConnection();
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
