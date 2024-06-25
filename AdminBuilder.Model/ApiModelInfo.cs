using AdminBuilder.Utils.AttributeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Model
{
    public class ApiModelInfo
    {
        [Model("方案id", "Id",false)]
        public int Id { get; set; }

        [Model("方案名称", "Name")]
        public string Name { get; set; } = string.Empty;

        [Model("备注", "Description")]
        public string Description { get; set; } = string.Empty;

        [Model("模板路径", "InPutPath", isFile: true)]
        public string InPutPath { get; set; } = "Out";

        [Model("输出路径", "OutPutPath")]
        public string OutPutPath { get; set; } = string.Empty;

        [Model("输出文件后缀", "OutPutEnd")]
        public string OutPutEnd { get; set; } = string.Empty;

        [Model("输出文件名", "OutPutFileEnd")]
        public string OutPutFileEnd { get; set; } = string.Empty;

        [Model("语言类型", "ClassType", isComboBox:true,new string[] {"java","dotnet","python"})]
        public string ClassType { get; set; } = string.Empty;

        public ApiModelInfo() { }

        public ApiModelInfo(string name, string description, string inputPath, string outPutPath)
        {
            Name = name;
            Description = description;
            InPutPath = inputPath;
            OutPutPath = outPutPath;
        }
    }


}
