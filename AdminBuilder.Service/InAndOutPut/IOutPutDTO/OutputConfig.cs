using AdminBuilder.Model;
using AdminBuilder.Utils.ConfigManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Service.InAndOutPut.IOutPutDTO
{

    public static class OutPutConfigManager
    {
        public static void Init()
        {
            ConfigurationManager.InitConfig += InitConfig;
        }

        public static void InitConfig()
        {
            ConfigurationManager.InitAddConfig(new AdminAppConfig(nameof(ApiModelInfo),nameof(ApiModelInfo),true));
            ConfigurationManager.InitAddConfig(new AdminAppConfig(nameof(TableMapper), nameof(TableMapper),true));
        }
    }

}
