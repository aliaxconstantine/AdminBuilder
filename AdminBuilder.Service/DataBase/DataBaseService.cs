using AdminBuilder.Model;
using AdminBuilder.Utils.DataBaseConfig;
using System;
using System.Collections.Generic;


namespace AdminBuilder.Service.DataBase
{
    public class DataBaseService:IDataBaseService
    {
        
        //获取数据库信息
        public DataBaseInfo GetDataBaseInfo(string name)
        {
           var dataBase = DataBaseConstants.GetSqlSugarClient(name);
            List<string> tableNames = new List<string>();
            dataBase.DbMaintenance.GetTableInfoList(true).ForEach(n =>
            {
                tableNames.Add(n.Name);
            });

            var info = new DataBaseInfo(name,"1",tableNames);
            return info;
        }

        /// <summary>
        /// 获取所有数据库
        /// </summary>
        /// <returns></returns>
        List<DataBaseInfo> IDataBaseService.GetALllDataBaseInfo()
        {
            List<DataBaseInfo> dataBaseInfos = new List<DataBaseInfo>();
           foreach(var name in DataBaseConstants.sqlSugarClients.Keys)
            {
               dataBaseInfos.Add(GetDataBaseInfo(name));
            }
           return dataBaseInfos;
        }
    }
}
