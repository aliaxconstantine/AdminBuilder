using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Utils.AttributeUtils
{
    public static class ModelAttributeUtil
    {
        /// <summary>
        /// 获取类中所有属性
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static Dictionary<ModelAttribute,string> GetModelAttribute<T>()
        {
            Type type = typeof(T);
            var properties = type.GetProperties();
            var attributes = new Dictionary<ModelAttribute,string>();   
            properties.ForEach(p =>
            {
                var value = p.GetCustomAttribute<ModelAttribute>();
                attributes.Add(value , p.PropertyType.ToString());
            });
            return attributes;
        }
    }
}
