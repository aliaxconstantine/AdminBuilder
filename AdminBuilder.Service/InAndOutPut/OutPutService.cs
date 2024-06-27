using AdminBuilder.Model;
using AdminBuilder.Service.InAndOutPut.IOutPutDTO;
using AdminBuilder.Utils.ConfigManager;
using MySqlX.XDevAPI.Common;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
namespace AdminBuilder.Service.InAndOutPut
{
    public class OutPutService : IOutPutService
    {
        public readonly string ClassKey = nameof(ApiModelInfo);
        public readonly string TableClassKey = nameof(TableMapper);
        public void OutPutVue(OutPutTableDTO outPut, VueModelInfo vueModelInfo)
        {
            throw new NotImplementedException();
        }

        public void InPutExcel(OutPutTableDTO outPut, string outPutPath)
        {
            throw new NotImplementedException();
        }
        public void OutPutApi(OutPutTableDTO outPut, ApiModelInfo apiModelInfo)
        {
            try
            {
                outPut.TypeClass = apiModelInfo.ClassType;
                // 获取输入和输出路径
                var inPutPath = apiModelInfo.InPutPath;
                var outPutPath = apiModelInfo.OutPutPath;
                // 读取模板内容
                string template = File.ReadAllText(inPutPath);
                // 提取模板中的多次模板部分并删除它们，记录删除次序
                var manyList = ExtractText(template);
                var outManyList = new List<string>();
                // 获取表名的大小驼峰格式
                string tableNameUpperCamel = ConvertToCamelCase(outPut.TableName, true);
                string tableNameLowerCamel = ConvertToCamelCase(outPut.TableName, false);
                foreach (var column in outPut.calumnious)
                {
                    // 获取列名的大小驼峰格式
                    string propertyNameLowerCamel = ConvertToCamelCase(column.ColumnName, false);
                    string propertyNameUpperCamel = ConvertToCamelCase(column.ColumnName, true);

                    foreach (var t in manyList)
                    {
                        var result = ReplacePlaceholder(t, "属性名称", propertyNameLowerCamel);
                        result = ReplacePlaceholder(result, "原属性名", propertyNameLowerCamel);
                        result = ReplacePlaceholder(result, "属性名称类", propertyNameUpperCamel);
                        result = ReplacePlaceholder(result, "属性类型", TableTypeToType(column.DataType, outPut).outTableName);
                        result = ReplacePlaceholder(result,"默认值",TableTypeToType(column.DataType, outPut).DefaultValue);
                        outManyList.Add(result);
                    }
                }
                // 删除全文中的占位符
                template = RemoveText(template);
                // 替换模板中的 %% 占位符为实际生成的字符串集合
                template = ReplacePlaceholder(template, "%%", outManyList);
                // 匹配表名与表属性
                template = ReplacePlaceholder(template, "原表名",outPut.TableName);
                template = ReplacePlaceholder(template, "表名", tableNameLowerCamel);
                template = ReplacePlaceholder(template, "表名类", tableNameUpperCamel);
                outPutPath = Path.Combine(outPutPath, tableNameUpperCamel+apiModelInfo.OutPutFileEnd+apiModelInfo.OutPutEnd);
                // 将替换后的模板写入输出文件
                using (StreamWriter writer = new StreamWriter(outPutPath, false, Encoding.UTF8))
                {
                    writer.Write(template.Trim());  // 写入模板内容
                }
            }
            catch (Exception ex)
            {
                throw new ApplicationException("输出错误，请查看是否创建相应数据库映射", ex);
            }
        }
        /// <summary>
        /// 用于替换指定占位符
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="placeholder">需要替换的占位符</param>
        /// <param name="replacement">替换内容</param>
        /// <returns>处理后的字符串</returns>
        private string ReplacePlaceholder(string input, string placeholder, string replacement)
        {
            // 构建正则表达式模式，匹配形如[placeholder]的占位符
            string pattern = $"\\[{placeholder}\\]";
            // 使用正则表达式进行替换
            return Regex.Replace(input, pattern, replacement);
        }

        /// <summary>
        /// 获取文本中所有以 "%%" 包含的文本组成的集合
        /// </summary>
        /// <param name="input">输入的文本内容</param>
        /// <returns>包含所有匹配文本的集合</returns>
        private List<string> ExtractText(string input)
        {
            List<string> result = new List<string>();
            string pattern = @"%\s*([^%]+)\s*%";
            MatchCollection matches = Regex.Matches(input, pattern);
            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    string extractedText = match.Groups[1].Value.Trim();
                    result.Add(extractedText);
                }
            }
            return result;
        }

        /// <summary>
        /// 删除带有%% 的字符串
        /// </summary>
        /// <param name="input">输入的文本内容</param>
        /// <returns>处理后的字符串</returns>
        private string RemoveText(string input)
        {
            string pattern = @"%\s*([^%]+)\s*%";
            return Regex.Replace(input, pattern, "%%");
        }

        /// <summary>
        /// 获取表名转换为类名
        /// </summary>
        /// <param name="input">数据库中的列类型</param>
        /// <param name="outPut">包含映射信息的输出对象</param>
        /// <returns>对应的C#类型</returns>
        private TableMapper TableTypeToType(string input, OutPutTableDTO outPut)
        {
            if (outPut.TableName == null)
            {
                throw new Exception("未查询到相关映射");
            }
            var dbType = outPut.DataBaseType;
            // 获取配置中的映射列表
            var mappers = ConfigurationManager.GetConfig(new AdminAppConfig(TableClassKey, TableClassKey), new List<TableMapper>());
            // 查找匹配的映射
            var mapper = mappers.FirstOrDefault(t => t.TableName == dbType && t.inTableName == input && t.ClassType == outPut.TypeClass);
            return mapper ?? throw new Exception("未查询到相关映射");
        }



        /// <summary>
        /// 替换模板中的占位符方法
        /// </summary>
        /// <param name="template">模板内容</param>
        /// <param name="placeholder">占位符</param>
        /// <param name="replacements">替换内容列表</param>
        /// <returns>处理后的字符串</returns>
        private string ReplacePlaceholder(string template, string placeholder, List<string> replacements)
        {
            var sb = new StringBuilder(template);

            int index = sb.ToString().IndexOf(placeholder);
            if (index != -1)
            {
                sb.Remove(index, placeholder.Length);
                string newLine = Environment.NewLine;
                string insertString = string.Join($"{newLine}        ", replacements);
                sb.Insert(index, insertString);
            }
            string result = sb.ToString().Replace(placeholder,"");

            return result;
        }


        /// <summary>
        /// 将字符串转为驼峰命名法
        /// </summary>
        /// <param name="input">输入字符串</param>
        /// <param name="upperFirstLetter">是否首字母大写</param>
        /// <returns>驼峰命名法的字符串</returns>
        private string ConvertToCamelCase(string input, bool upperFirstLetter)
        {
            var apiToOther = new ApiToOther { OldString = input };
            return upperFirstLetter ? apiToOther.GetCamelCaseUpper() : apiToOther.GetCamelCaseLower();
        }

        public List<ApiModelInfo> GetApiOutputConfigDates()
        {
            return ConfigurationManager.GetConfig(new AdminAppConfig(ClassKey, ClassKey), new List<ApiModelInfo>());
        }


        public bool AddApiConfg(ApiModelInfo apiOutputConfigData)
        {
            var value = GetApiOutputConfigDates();
            if (value != null)
            {
                value.Add(apiOutputConfigData);
            }
            ConfigurationManager.SetT(new AdminAppConfig(ClassKey,ClassKey),value);
            return true;
        }
    }
}
