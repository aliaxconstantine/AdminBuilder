using AdminBuilder.Model;
using AdminBuilder.Service.InAndOutPut.IOutPutDTO;
using AdminBuilder.Utils.ConfigManager;
using AdminBuilder.Utils.DataBaseConfig;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdminBuilder.Service.DataModel
{
    public class DataModelService : IDataModelService
    {
        public readonly string ClassKey = nameof(ApiModelInfo);
        public readonly string TableClassKey = nameof(TableMapper);
        public bool AddApiDataModel(ApiModelInfo model)
        {
            var config = ConfigurationManager.GetConfig(new AdminAppConfig(ClassKey, ClassKey), new List<ApiModelInfo>());
            if(config == null)
            {
                return false;
            }
            if(model.Id == 0)
            {
                model.Id = config.Count+1;
            }
            config.Add(model);
            return true;
        }

        public bool AddVueDataModel(VueModelInfo model)
        {
            throw new NotImplementedException();
        }

        public bool DeleteApiDataModel(int id)
        {
            var config = ConfigurationManager.GetConfig(new AdminAppConfig(ClassKey, ClassKey), new List<ApiModelInfo>());
            if (config == null)
            {
                return false;
            }
            config.Remove(config.Find(t => t.Id == id));
            return true;
        }

        public bool DeleteVueDataModel(int id)
        {
            throw new NotImplementedException();
        }

        public bool UpdateApiDataModel(ApiModelInfo model)
        {
            
            var config = ConfigurationManager.GetConfig(new AdminAppConfig(ClassKey, ClassKey), new List<ApiModelInfo>());
            if (config == null)
            {
                return false;
            }
            var info = config.Find(t => t.Id == model.Id);
            if(info == null)
            {
                return false;
            }
            DeleteApiDataModel(model.Id);
            AddApiDataModel(model);
            return true;
        }

        public bool UpdateVueDataModel(VueModelInfo model)
        {
            throw new NotImplementedException();
        }

        public List<ApiModelInfo> GetAllApiDataModel(int pageNum)
        {
            var config = ConfigurationManager.GetConfig(new AdminAppConfig(ClassKey, ClassKey), new List<ApiModelInfo>());
            var models = new List<ApiModelInfo>();
            if(config == null)
            {
                return models ;
            }
            if(config.Count == 0)
            {
                models.Add(new ApiModelInfo() { Id = 0});
            }
            config.ForEach(v =>
            {
                models.Add(v);
            });
            return models.Skip(DataBaseConstants.PageIndex*(pageNum - 1)).Take(DataBaseConstants.PageIndex).ToList();
        }

        public List<VueModelInfo> GetAllVueDataModel(int pageNum)
        {
            return new List<VueModelInfo>() { };
        }

        public VueModelInfo GetVueModelInfo(int id)
        {
            throw new NotImplementedException();
        }

        public ApiModelInfo GetApiModelInfo(int id)
        {
            var config = ConfigurationManager.GetConfig(new AdminAppConfig(ClassKey, ClassKey), new List<ApiModelInfo>());
            if (config == null)
            {
                return new ApiModelInfo();
            }
            var info = config.Find(t => t.Id == id);
            if (info == null)
            {
                return new ApiModelInfo();
            }
            return info;
        }

        public List<TableMapper> GetTableMappers(int pageNum)
        {
            var config = ConfigurationManager.GetConfig(new AdminAppConfig(TableClassKey, TableClassKey), new List<TableMapper>());
            if (config == null)
            {
                return new List<TableMapper>();
            }
            if(config.Count == 0)
            {
                config.Add(new TableMapper()
                {
                    TableMapperId = 0,
                }) ;
            }
            return config.Skip((pageNum-1)* DataBaseConstants.PageIndex ).Take(DataBaseConstants.PageIndex).ToList();
        }

        public bool DeleteTableMapper(TableMapper tableMapper)
        {
            var config = ConfigurationManager.GetConfig(new AdminAppConfig(TableClassKey, TableClassKey), new List<TableMapper>());
            if(config == null)
            {
                throw new Exception("映射表未初始化");
            }
            var ta = config.Find(t => t.TableMapperId == tableMapper.TableMapperId);
            if(ta == null)
            {
                throw new Exception( $"{tableMapper.TableMapperId}未知id");
            }
            config.Remove(ta);
            return true;
        }

        public bool UpdateTableMapper(TableMapper tableMapper)
        {
            var config = ConfigurationManager.GetConfig(new AdminAppConfig(TableClassKey, TableClassKey), new List<TableMapper>());
            if (config == null)
            {
                throw new Exception("映射表未初始化");
            }
            var ta = config.Find(t => t.TableMapperId == tableMapper.TableMapperId);
            if (ta == null)
            {
                throw new Exception($"{tableMapper.TableMapperId}未知id");
            }
            DeleteTableMapper(tableMapper);
            AddTableMapper(tableMapper);
            return true;
        }

        public bool AddTableMapper(TableMapper tableMapper)
        {
            var config = ConfigurationManager.GetConfig(new AdminAppConfig(TableClassKey, TableClassKey), new List<TableMapper>());
            if (config == null)
            {
                throw new Exception("映射表未初始化");
            }
            if(tableMapper.TableMapperId == 0)
            {
                tableMapper.TableMapperId = config.Count+1;
            }
            config.Add(tableMapper);
            return true;    
        }
    }
}
