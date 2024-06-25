using AdminBuilder.Views;
using AdminBuilder.Views.Main;
using AdminBuilder.Views.OtherForm;
using Autofac;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminBuilder.Config
{
    public class AutoFacConfig
    {
        private static readonly string _name = "AdminBuilder.Service";
        public static readonly string model_name = "AdminBuilder.Model";

        //重写Autofac 注册注入方法
        public static IContainer AutoFacContainer;
 
        public static void BuildContainer()
        {
            var builder = new ContainerBuilder();
            //程序集注入业务服务
            var IAppServices = Assembly.Load(_name);
            var AppServices = Assembly.Load(_name);
            //根据名称注入
            builder.RegisterAssemblyTypes(IAppServices, AppServices).Where(t =>
                t.Name.EndsWith("Service")
            ).AsImplementedInterfaces().PropertiesAutowired();
            builder.RegisterType<AdminBuilderForm>().PropertiesAutowired();
            builder.RegisterType<MainPage>().PropertiesAutowired();
            builder.RegisterType<CreateDatabasePage>().PropertiesAutowired();
            builder.RegisterType<ApiConfigPage>().PropertiesAutowired();
            builder.RegisterType<CodeConfigPage>().PropertiesAutowired();
            builder.RegisterType<ConnectionPage>().PropertiesAutowired();
            builder.RegisterType<TableMapperPage>().PropertiesAutowired();
            builder.RegisterType<CreateApiPage>().PropertiesAutowired();
            builder.RegisterType<HelpPage>().PropertiesAutowired();
            AutoFacContainer = builder.Build();
        }
    }
}
