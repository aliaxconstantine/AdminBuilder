using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Service.InAndOutPut.IOutPutDTO
{
    public enum StringType
    {
        /// <summary>
        /// 大写
        /// </summary>
        Upper,
        /// <summary>
        /// 小写
        /// </summary>
        Lower,
        /// <summary>
        /// 下划线
        /// </summary>
        Underscore
    }

    public class ApiToOther
    {
        public string OldString { get; set; } = string.Empty;
        public StringType OldStringType { get; set; } = StringType.Underscore;

        public ApiToOther() { }

        /// <summary>
        /// 获取驼峰命名 首字母小写
        /// </summary>
        /// <returns></returns>
        public string GetCamelCaseLower()
        {
            if (string.IsNullOrEmpty(OldString))
                return OldString;

            string processedString = ProcessOldString();
            return char.ToLower(processedString[0]) + processedString.Substring(1);
        }

        /// <summary>
        /// 获取驼峰命名 首字母大写
        /// </summary>
        /// <returns></returns>
        public string GetCamelCaseUpper()
        {
            if (string.IsNullOrEmpty(OldString))
                return OldString;

            string processedString = ProcessOldString();
            return char.ToUpper(processedString[0]) + processedString.Substring(1);
        }

        /// <summary>
        /// 根据 OldStringType 处理 OldString
        /// </summary>
        /// <returns></returns>
        private string ProcessOldString()
        {
            string processedString = OldString;

            switch (OldStringType)
            {
                case StringType.Upper:
                    processedString = OldString.ToLower();
                    break;
                case StringType.Lower:
                    processedString = OldString;
                    break;
                case StringType.Underscore:
                    // 替换下划线后的首字母大写, 然后去掉下划线
                    processedString = string.Join("", processedString.Split('_').Select(s => char.ToUpper(s[0]) + s.Substring(1)));
                    break;
                default:
                    throw new ArgumentException("Invalid OldStringType");
            }

            return processedString;
        }
    }


}
