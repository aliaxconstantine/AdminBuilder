using AdminBuilder.Model;
using AdminBuilder.Service.InAndOutPut.IOutPutDTO;
using Sunny.UI.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Service.DataModel
{
    public interface IDataModelService
    {
        bool AddTableMapper(TableMapper tableMapper);
        bool DeleteTableMapper(TableMapper tableMapper);
        bool UpdateTableMapper(TableMapper tableMapper);
        List<ApiModelInfo> GetAllApiDataModel(int pageNum);
       List<VueModelInfo> GetAllVueDataModel(int pageNum);

        List<TableMapper> GetTableMappers(int pageNum);

        bool AddApiDataModel(ApiModelInfo model);
        bool AddVueDataModel(VueModelInfo model);
        bool DeleteApiDataModel(int id);
        bool DeleteVueDataModel(int id);
        bool UpdateApiDataModel(ApiModelInfo model);
        bool UpdateVueDataModel(VueModelInfo model);
        VueModelInfo GetVueModelInfo(int id);
        ApiModelInfo GetApiModelInfo(int id);
    }
}
