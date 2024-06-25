using Sunny.UI;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IdentityModel.Metadata;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Input;

namespace AdminBuilder.Utils.ConfigManager
{
    public static class ConfigurationManager
    {
        public static readonly string JsonFilePath = "DataConfig.json";
        public static Assembly CurrentlyAssembly = Assembly.GetExecutingAssembly();
        private static Dictionary<AdminAppConfig, object> ConfigData = new Dictionary<AdminAppConfig, object>();

        public static Action InitConfig;

        /// <summary>
        /// 在初始化之前添加配置类
        /// </summary>
        /// <param name="configName"></param>
        public static void InitAddConfig(AdminAppConfig configName)
        {
            if(ConfigData.Any(t => t.Key.Name == configName.Name))
            {
                return;
            }
            ConfigData.Add(configName, null);
        }

        public static void RemoveConfig(AdminAppConfig configName)
        {
            ConfigData.Remove(configName);
        }
        /// <summary>
        /// 获取配置对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configName"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        /// <exception cref="InvalidCastException"></exception>
        public static T GetConfig<T>(AdminAppConfig configName, T defaultT)
        {
            InitConfig?.Invoke();
            var matchingItem = ConfigData.FirstOrDefault(t => t.Key.Name == configName.Name);
            var result = matchingItem.Value == null;
            configName = matchingItem.Key;
            if (result)
            {
                SetT(configName, defaultT);
                return defaultT;
            }
            else
            {
                try
                {
                    return (T)ConfigData[configName];
                }
                catch (InvalidCastException)
                {
                    throw new InvalidCastException($"Configuration section '{configName}' cannot be cast to type {typeof(T).Name}.");
                }
            }
        }

        /// <summary>
        /// 设置
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="configName"></param>
        /// <param name="value"></param>
        public static void SetT<T>(AdminAppConfig configName, T value)
        {
            ConfigData[configName] = value;
        }

        private static Type GetTypeByName(string name)
        {
            var types = CurrentlyAssembly.GetTypes();
            return types.FirstOrDefault(t => t.Name == name);
        }

        /// <summary>
        /// 写json配置
        /// </summary>
        /// <param name="jsonFilePath"></param>
        /// <param name="configDictionary"></param>
        public static void WriteConfigToJson()
        {
            string jsonFilePath = JsonFilePath;
            Dictionary<AdminAppConfig, object> configDictionary = ConfigData;
            var options = new JsonSerializerOptions
            {
                WriteIndented = true
            };

            var jsonDocument = new Dictionary<string, JsonElement>();

            var keysToUpdate = new List<AdminAppConfig>();
            foreach (var kvp in configDictionary)
            {
                if (kvp.Value == null && kvp.Key.IsList)
                {
                    keysToUpdate.Add(kvp.Key);
                }
            }
            foreach (var key in keysToUpdate)
            {
                if (key.IsList)
                {
                    var type = GetTypeByName(key.Type);
                    var listType = typeof(List<>).MakeGenericType(type);
                    var list = Activator.CreateInstance(listType);
                    ConfigData[key] = list;
                }
                else
                {
                    var type = GetTypeByName(key.Type);
                    var value = Activator.CreateInstance(type);
                    configDictionary[key] = value;
                }
            }

            foreach (var kvp in configDictionary)
            {
                var jsonString = JsonSerializer.Serialize(kvp.Value, kvp.Value.GetType(), options);
                var jsonElement = JsonDocument.Parse(jsonString).RootElement;
                jsonDocument[kvp.Key.Name] = jsonElement;
            }

            var finalJsonString = JsonSerializer.Serialize(jsonDocument, options);
            File.WriteAllText(jsonFilePath, finalJsonString);
        }

        /// <summary>
        /// 根据设置列表读取json配置
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        private static void ReadFromJson()
        {
            if (!File.Exists(JsonFilePath))
            {
                File.WriteAllText(JsonFilePath, "{}");
            }

            var jsonData = File.ReadAllText(JsonFilePath);
            var jsonDocument = JsonDocument.Parse(jsonData);

            var configDictionary = new Dictionary<AdminAppConfig, object>();

            foreach (var element in jsonDocument.RootElement.EnumerateObject())
            {
                string key = element.Name;
                var type = GetTypeByName(key);
                AdminAppConfig adminAppConfig = new AdminAppConfig(key,key);
                if (type != null)
                {
                    // 检查是否是数组类型
                    if (element.Value.ValueKind == JsonValueKind.Array)
                    {
                        //创建泛型列表
                        var list = (IList)Activator.CreateInstance(typeof(List<>).MakeGenericType(type));
                        //遍历列表元素
                        foreach (var item in element.Value.EnumerateArray())
                        {
                            var deserializedItem = JsonSerializer.Deserialize(item.GetRawText(), type);
                            list.Add(deserializedItem);
                        }
                        adminAppConfig.IsList = true;
                        configDictionary.Add(adminAppConfig, list);
                    }
                    else
                    {
                        var value = JsonSerializer.Deserialize(element.Value.GetRawText(), type);
                        configDictionary.Add(adminAppConfig, value);
                    }
                }
                else
                {
                    throw new InvalidOperationException($"程序集中不存在该类: {key}");
                }
            }
            ConfigData = configDictionary;
        }

        /// <summary>
        /// 初始化配置类
        /// </summary>
        public static void InitReadConfig(Assembly assembly = null)
        {
            if (assembly != null)
            {
                CurrentlyAssembly = assembly;
            }
            ReadFromJson();
        }
    }

}
