using AdminBuilder.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Service.View
{
    public interface IViewService
    {
        List<TableBaseInfo> GetViewBases(string dataBaseName);
        List<ColumnInfo> GetColumnInfos(string dataBaseName,string viewName);
        List<TableBaseInfo> GetAllViews(string dataBaseName, int PageNum);
        List<ColumnInfo> GetAllColumInfo(string dataBaseName, string viewName , int PageNum);

        bool UpDateView(TableBaseInfo viewBaseInfo,string dataBaseName);
        bool UpDateColumn(ColumnInfo columnInfo,string viewName, string dataBaseName);
        bool AddView(TableBaseInfo viewBaseInfo,string dataBaseName);
        bool AddColumn(ColumnInfo columnInfo,string viewName, string dataBaseName);

        bool DelView(string  dataBaseName,string viewName);
        bool DelColumn(string dataBaseName,string viewName,string ColumnName);

        TableBaseInfo GetView(string dataBaseName,string viewName);
        ColumnInfo GetColumnInfo(string dataBaseName,string ViewName,string columnInfo);
    }
}
