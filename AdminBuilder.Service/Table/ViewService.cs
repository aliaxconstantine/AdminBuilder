using AdminBuilder.Model;
using AdminBuilder.Utils.DataBaseConfig;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;

namespace AdminBuilder.Service.View
{
    public class ViewService : IViewService
    {

        public List<ColumnInfo> GetColumnInfos(string dataBaseName, string viewName)
        {
            var dataBase = DataBaseConstants.GetSqlSugarClient(dataBaseName);
            if (dataBase == null)
            {
                return new List<ColumnInfo>();
            }
            var infoList = new List<ColumnInfo>();
            dataBase.DbMaintenance.GetColumnInfosByTableName(viewName).ForEach(info =>
            {
                var data = new ColumnInfo(info.DbColumnName, info.DataType, info.IsNullable, info.IsPrimarykey)
                {
                    Description = info.ColumnDescription
                };
                infoList.Add(data);
            });

            return infoList;
        }

        public List<TableBaseInfo> GetViewBases(string dataBaseName)
        {
            var dataBase = DataBaseConstants.GetSqlSugarClient(dataBaseName);
            if (dataBase == null)
            {
               return new List<TableBaseInfo>();
            }
            var views = new List<TableBaseInfo>();
            var dbViews = dataBase.DbMaintenance.GetTableInfoList();
            dbViews.ForEach(info =>
            {
                var data = new TableBaseInfo(info.Name)
                {
                    Desc = info.Description
                };
                views.Add(data);
            });
            return views;
        }


        public List<ColumnInfo> GetAllColumInfo(string dataBaseName,string viewName,int pageNum)
        {

            return GetColumnInfos(dataBaseName,viewName).Skip(DataBaseConstants.PageIndex * (pageNum -1)).Take(DataBaseConstants.PageIndex).ToList();
        }

        public List<TableBaseInfo> GetAllViews(string dataBaseName, int pageNum)
        {

            return GetViewBases(dataBaseName).Skip(DataBaseConstants.PageIndex * (pageNum - 1)).Take(DataBaseConstants.PageIndex).ToList();
        }

        public bool AddColumn(ColumnInfo columnInfo, string tableName, string dataBaseName)
        {
            return DataBaseConstants.GetSqlSugarClient(dataBaseName).DbMaintenance.AddColumn(tableName, new DbColumnInfo()
            {
                DataType = columnInfo.DataType,
                DbColumnName = columnInfo.ColumnName,
                IsPrimarykey = columnInfo.isMain,
                IsNullable = columnInfo.IsNullable,
            });
        }

        public bool AddView(TableBaseInfo viewBaseInfo, string dataBaseName)
        {
            return DataBaseConstants.GetSqlSugarClient(dataBaseName).DbMaintenance.AddTableRemark(viewBaseInfo.TableName, viewBaseInfo.Desc);
        }

        public bool UpDateColumn(ColumnInfo columnInfo, string viewName, string dataBaseName)
        {
            var dbClient = DataBaseConstants.GetSqlSugarClient(dataBaseName);

            try
            {
                // 开启事务
                dbClient.Ado.BeginTran();
                var oldDbColumnInfo = dbClient.DbMaintenance.GetColumnInfosByTableName(viewName)
                                            .Find(t => t.DbColumnName == columnInfo.OldName);

                // 更新列信息
                oldDbColumnInfo.DataType = columnInfo.DataType;
                oldDbColumnInfo.IsNullable = columnInfo.IsNullable;
                oldDbColumnInfo.IsPrimarykey = columnInfo.isMain;

                bool updateInfo = dbClient.DbMaintenance.UpdateColumn(viewName, oldDbColumnInfo);
                //如果存在先删除
                if(dbClient.DbMaintenance.IsAnyColumnRemark(oldDbColumnInfo.DbColumnName, viewName))
                {
                    dbClient.DbMaintenance.DeleteColumnRemark(oldDbColumnInfo.DbColumnName, viewName);
                }
                bool updateDesc = dbClient.DbMaintenance.AddColumnRemark(oldDbColumnInfo.DbColumnName, viewName, columnInfo.Description);
                bool updateName = dbClient.DbMaintenance.RenameColumn(viewName, oldDbColumnInfo.DbColumnName, columnInfo.ColumnName);

                if (updateInfo && updateDesc && updateName)
                {
                    dbClient.Ado.CommitTran();
                    return true; 
                }
                else
                {
                    dbClient.Ado.RollbackTran(); 
                    return false; 
                }
            }
            catch (Exception)
            {
                dbClient.Ado.RollbackTran(); 
                return false;
            }
        }


        public bool UpDateView(TableBaseInfo viewBaseInfo, string dataBaseName)
        {
            var dbClient = DataBaseConstants.GetSqlSugarClient(dataBaseName);
            try
            {
                dbClient.Ado.BeginTran();
                bool rename = dbClient.DbMaintenance.RenameTable(viewBaseInfo.OldName, viewBaseInfo.TableName);
                if(!rename)
                {
                    dbClient.Ado.RollbackTran();
                    return false;
                }
                //如果存在先删除
                if (dbClient.DbMaintenance.IsAnyTableRemark(viewBaseInfo.TableName))
                {
                    dbClient.DbMaintenance.DeleteColumnRemark(viewBaseInfo.TableName, viewBaseInfo.Desc);
                }
                bool redesc = dbClient.DbMaintenance.AddTableRemark(viewBaseInfo.TableName, viewBaseInfo.Desc);
                dbClient.Ado.CommitTran();
                if (rename && redesc)
                {
                    dbClient.Ado.CommitTran();
                    return true;
                }
                else
                {
                    dbClient.Ado.RollbackTran();
                    return false;
                }
            }
            catch(Exception)
            {
                dbClient.Ado.RollbackTran();
                return false;
            }
        }

        public bool DelView(string dataBaseName, string viewName)
        {
            return DataBaseConstants.GetSqlSugarClient(dataBaseName).DbMaintenance.DeleteTableRemark(viewName);
        }

        public bool DelColumn(string datdBaseName,string viewName, string ColumnName)
        {
            return DataBaseConstants.GetSqlSugarClient(datdBaseName).DbMaintenance.DeleteColumnRemark(viewName, ColumnName);
        }

        public TableBaseInfo GetView(string dataBaseName, string viewName)
        {
            var data = GetViewBases(dataBaseName).Find(t => t.TableName == viewName);
            data.OldName = data.TableName;
           return data;
        }

        public ColumnInfo GetColumnInfo(string dataBaseName, string viewName, string columnInfo)
        {
            var dbData = DataBaseConstants.GetSqlSugarClient(dataBaseName).DbMaintenance.GetColumnInfosByTableName(viewName).Find(t => t.DbColumnName == columnInfo);
            var data = new ColumnInfo();
            data.OldName = dbData.DbColumnName;
            data.ColumnName = dbData.DbColumnName;
            data.Description = dbData.ColumnDescription;
            data.DataType = dbData.DataType;
            data.IsNullable = dbData.IsNullable;
            data.isMain = dbData.IsPrimarykey;
            return data;
        }
    }
}
