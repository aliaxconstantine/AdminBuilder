using AdminBuilder.Model;
using AdminBuilder.Service.Connection;
using AdminBuilder.Service.EventModelDTO;
using AdminBuilder.Utils.ControlEvent;
using AdminBuilder.Utils.DataBaseConfig;
using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using static System.Net.Mime.MediaTypeNames;

namespace AdminBuilder.Service.View
{
    public class ViewService : IViewService
    {
        //更新表
        public void FreshTable(string dataBaseName,string tableName)
        {
            DataEventManager.Instance.Dispatch(nameof(DataViewEventArgs),new DataRefreshEventArgs()
            {
                Data = JsonConvert.SerializeObject(new DataViewEventArgs()
                {
                    ViewName = tableName,
                    DataBaseName = dataBaseName,
                    FreshType = AppConstants.ViewKey
                })
            });
        }

        public void FreshColumn(string dataBaseName,string tableName)
        {
            DataEventManager.Instance.Dispatch(nameof(DataViewEventArgs), new DataRefreshEventArgs()
            {
                Data = JsonConvert.SerializeObject(new DataViewEventArgs()
                {
                    ViewName = tableName,
                    DataBaseName = dataBaseName,
                    FreshType = AppConstants.ColumnKey
                })
            });
        }


        public List<ColumnInfo> GetColumnInfos(string dataBaseName, string viewName)
        {
            var dataBase = DataBaseConstants.GetSqlSugarClient(dataBaseName);
            if (dataBase == null)
            {
                return new List<ColumnInfo>();
            }
            var infoList = new List<ColumnInfo>();
            dataBase.DbMaintenance.GetColumnInfosByTableName(viewName,false).ForEach(info =>
            {
                var data = new ColumnInfo(info.DbColumnName, info.DataType, info.IsNullable, info.IsPrimarykey);
                if (info.ColumnDescription != null)
                {
                    data.Description = info.ColumnDescription;
                }
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
            var dbViews = dataBase.DbMaintenance.GetTableInfoList(false);
            dbViews.ForEach(info =>
            {
                var data = new TableBaseInfo(info.Name);
                if(info.Description != null)
                {
                    data.Desc = info.Description;
                }
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
            var data = new DbColumnInfo()
            {
                DataType = columnInfo.DataType,
                DbColumnName = columnInfo.ColumnName,
                IsPrimarykey = columnInfo.isMain,
                IsNullable = columnInfo.IsNullable,

            };

            bool result =  DataBaseConstants.GetSqlSugarClient(dataBaseName).DbMaintenance.AddColumn(tableName,data );
            //修改注释
            if (columnInfo.Description != null && result)
            {
                DataBaseConstants.GetSqlSugarClient(dataBaseName).DbMaintenance.AddColumnRemark(data.DbColumnName,tableName,columnInfo.Description);  
            }
            FreshColumn(dataBaseName,tableName);
            return result;
        }

        public bool AddView(TableBaseInfo tableInfo, string dataBaseName)
        {

            bool result = DataBaseConstants.GetSqlSugarClient(dataBaseName).DbMaintenance.CreateTable(tableInfo.TableName, new List<DbColumnInfo>()
            {
                new DbColumnInfo()
                {
                    DbColumnName = "id",
                    DataType = "int"
                }
            }) ;
            if (tableInfo.Desc != null && result)
            {
                DataBaseConstants.GetSqlSugarClient(dataBaseName).DbMaintenance.AddTableRemark(tableInfo.TableName, tableInfo.Desc);
            }
            FreshTable(dataBaseName, tableInfo.TableName);
            return result;
        }

        public bool UpDateColumn(ColumnInfo columnInfo, string viewName, string dataBaseName)
        {
            var dbClient = DataBaseConstants.GetSqlSugarClient(dataBaseName);

            try
            {
                // 开启事务
                dbClient.Ado.BeginTran();
                var oldDbColumnInfos = dbClient.DbMaintenance.GetColumnInfosByTableName(viewName,false);
                 var oldDbColumnInfo =  oldDbColumnInfos.Find(t => t.DbColumnName == columnInfo.OldName);
                if(oldDbColumnInfo == null)
                {
                    dbClient.Ado.CommitTran();
                    return false;
                }
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
                    FreshColumn(dataBaseName, viewName);
                    return true; 
                }
                else
                {
                    dbClient.Ado.RollbackTran(); 
                    return false; 
                }
            }
            catch (Exception e)
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
                var oldTable = GetView(dataBaseName, viewBaseInfo.OldName);
                bool rename = dbClient.DbMaintenance.RenameTable(viewBaseInfo.OldName, viewBaseInfo.TableName);
                if(!rename)
                {
                    dbClient.Ado.RollbackTran();
                    return false;
                }
                //如果存在先删除
                if (dbClient.DbMaintenance.IsAnyTableRemark(viewBaseInfo.TableName))
                {
                    dbClient.DbMaintenance.DeleteTableRemark(viewBaseInfo.TableName);
                }
                bool redesc = dbClient.DbMaintenance.AddTableRemark(viewBaseInfo.TableName, viewBaseInfo.Desc);
                dbClient.Ado.CommitTran();
                if (rename && redesc)
                {
                    dbClient.Ado.CommitTran();
                    FreshTable(dataBaseName, viewBaseInfo.TableName);
                    return true;
                }
                else
                {
                    dbClient.Ado.RollbackTran();
                    return false;
                }
            }
            catch(Exception e)
            {
                dbClient.Ado.RollbackTran();
                return false;
            }
        }

        public bool DelView(string dataBaseName, string viewName)
        {
            bool result = DataBaseConstants.GetSqlSugarClient(dataBaseName).DbMaintenance.DropTable(viewName);
            FreshTable(dataBaseName, viewName);
            return result;
        }

        public bool DelColumn(string dataBaseName,string viewName, string ColumnName)
        {
            bool result = DataBaseConstants.GetSqlSugarClient(dataBaseName).DbMaintenance.DropColumn(viewName, ColumnName);
            FreshColumn(dataBaseName, viewName);
            return result; 
        }

        public TableBaseInfo GetView(string dataBaseName, string viewName)
        {
            var data = GetViewBases(dataBaseName).Find(t => t.TableName == viewName);
            data.OldName = data.TableName;
           return data;
        }

        public ColumnInfo GetColumnInfo(string dataBaseName, string viewName, string columnInfo)
        {
            var dbData = DataBaseConstants.GetSqlSugarClient(dataBaseName).DbMaintenance.GetColumnInfosByTableName(viewName,false).Find(t => t.DbColumnName == columnInfo);
            var data = new ColumnInfo();
            data.OldName = dbData.DbColumnName;
            data.ColumnName = dbData.DbColumnName;
            if(dbData.ColumnDescription != null)
            {
                data.Description = dbData.ColumnDescription;
            }
            data.DataType = dbData.DataType;
            data.IsNullable = dbData.IsNullable;
            data.isMain = dbData.IsPrimarykey;
            return data;
        }
    }
}
