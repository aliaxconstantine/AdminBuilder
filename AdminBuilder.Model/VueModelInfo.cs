using AdminBuilder.Utils.AttributeUtils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Model
{
    public class VueModelInfo
    {
        [Model("方案id", "Id")]
        public int Id { get; set; } = 0;
        [Model("方案名称", "Name")]
        public string Name { get; set; } = string.Empty;
        [Model("备注", "Description")]
        public string Description { get; set; } = string.Empty;
        [Model("模板路径", "InPutPath",isFile: true)]
        public string InPutPath { get; set; } = string.Empty;
        [Model("输出路径", "OutPutPath", isFile: true)]
        public string OutPutPath { get;set; } = string.Empty;

        [Model("是否驼峰", "IsCamelCase")]
        public bool IsCamelCase { get; set; } = false;

        [Model("是否全部大写", "IsAllUppercase")]
        public bool IsAllUppercase { get; set; } = false;
        [Model("表属性转换路径", "")]
        public string TableTypeMappings { get; set; } = string.Empty;
        public VueModelInfo() { }
        public VueModelInfo(string name, string description, string outPutPath,string inPutPath)
        {
            Name = name;
            Description = description;
            OutPutPath = outPutPath;
            InPutPath = inPutPath;
        }
    }
}
