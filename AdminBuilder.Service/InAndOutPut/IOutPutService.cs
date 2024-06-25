using AdminBuilder.Model;
using AdminBuilder.Service.InAndOutPut.IOutPutDTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Service.InAndOutPut
{
    public interface IOutPutService
    {
        //获取所有配置
        List<ApiModelInfo> GetApiOutputConfigDates();
        
        bool AddApiConfg(ApiModelInfo apiOutputConfigData);
        //输出Api
        void OutPutApi(OutPutTableDTO outPut, ApiModelInfo apiModelInfo);
        //输出前端
        void OutPutVue(OutPutTableDTO outPut, VueModelInfo vueModelInfo);
        //输入表格
        void InPutExcel(OutPutTableDTO outPut, string outPutPath);
    }
}
