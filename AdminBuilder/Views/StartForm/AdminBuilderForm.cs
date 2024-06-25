using AdminBuilder.Model;
using AdminBuilder.Service.Connection;
using AdminBuilder.Service.DataBase;
using AdminBuilder.Service.EventModelDTO;
using AdminBuilder.Service.InAndOutPut;
using AdminBuilder.Utils;
using AdminBuilder.Utils.ConfigManager;
using AdminBuilder.Utils.ControlEvent;
using AdminBuilder.Utils.DataBaseConfig;
using AdminBuilder.Views.Main;
using DataEvent.Utils.ControlEvent;
using Newtonsoft.Json;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Security.Policy;
using System.Windows.Forms;

namespace AdminBuilder.Views
{
    public partial class AdminBuilderForm : UIHeaderAsideMainFrame, IEventListener
    {
        public List<TableBaseInfo> viewBaseInfo = new List<TableBaseInfo>();
        public DataBaseInfo currentlyDataBase;
        public readonly IDataBaseService dataBaseService;
        public readonly IOutPutService outPutService;
        public readonly IConnectionService connectionService;
        public readonly MainPage mainForm;
        public readonly ApiConfigPage configForm;
        public readonly CodeConfigPage codeConfigForm;
        public readonly ConnectionPage connectionForm;
        public readonly TableMapperPage tableMapperForm;
        public readonly HelpPage helpPage;
        public AdminBuilderForm(IOutPutService outPutService,IConnectionService connectionService, IDataBaseService dataBaseService, 
            MainPage mainForm,ApiConfigPage configForm, CodeConfigPage codeConfigForm,ConnectionPage connectionForm,
            TableMapperPage tableMapperForm,HelpPage helpPage)
        {
            InitializeComponent();
            this.dataBaseService = dataBaseService;
            this.outPutService = outPutService;
            this.connectionService = connectionService;
            this.mainForm = mainForm;
            this.configForm = configForm;
            this.codeConfigForm = codeConfigForm;
            this.connectionForm = connectionForm;
            this.tableMapperForm = tableMapperForm;
            this.helpPage = helpPage;
            InitAllControls();
            InitEvent();
        }

        private void InitAside()
        {
            int pageIndex = 1000;
            var dataNode = Aside.CreateNode("数据源管理", ++pageIndex);
            Aside.CreateChildNode(dataNode, "数据表管理", ++pageIndex);
            var configNode = Aside.CreateNode("模板配置", ++pageIndex);
            Aside.CreateChildNode(configNode, "Vue模板", ++pageIndex);
            Aside.CreateChildNode(configNode, "Api模板", ++pageIndex);
            Aside.CreateChildNode(configNode, "数据库映射", ++pageIndex);
            var configMNode = Aside.CreateNode("配置管理",++pageIndex);
            Aside.CreateChildNode(configMNode, "数据库连接管理", ++pageIndex);
            Aside.CreateChildNode(configMNode, "帮助", ++pageIndex);
        }

        public void InitEvent()
        {
            DataEventManager dataViewManager = DataEventManager.Instance;
            dataViewManager.AddListener(nameof(DataViewEventArgs),this);
            dataViewManager.AddListener(nameof(ControlFontEventArgs),this);
            dataViewManager.AddListener(nameof(DataViewEventArgs), mainForm);
            dataViewManager.AddListener(nameof(ControlFontEventArgs), mainForm);
            dataViewManager.AddListener(nameof(DataViewEventArgs), connectionForm);
        }

        public void InitAllControls()
        {
            InitAside();
            AddPage(mainForm, 1002);
            AddPage(configForm, 1005);
            AddPage(codeConfigForm, 1004);
            AddPage(connectionForm, 1008);
            AddPage(tableMapperForm, 1006);
            AddPage(helpPage,1009);
        }

        //初始化，通过本地存储读取数据库为侧边栏控件赋值
        public void HandleEvent(string eventType, DataRefreshEventArgs args)
        {
            switch (eventType) 
            {
                case nameof(ControlFontEventArgs):HandleFontFresh(args);
                    break;
            }
        }


        private void HandleFontFresh(DataRefreshEventArgs args)
        {
            //转换信息为json
            var data = JsonConvert.DeserializeObject<ControlFontEventArgs>(args.Data);
            this.TitleFont = new Font( data.FontStyle, data.FontNum);
            this.ForeColor = data.FontColor;

            this.CreateConnectionButton.Font = new Font(data.FontStyle, data.FontNum);
            this.CreateConnectionButton.ForeColor = data.FontColor;
        }

        private void uiSymbolButton1_Click(object sender, EventArgs e)
        {
            CreateDatabasePage createDatabaseForm = new CreateDatabasePage();
            createDatabaseForm.CreateDatabase += connectionService.CreateDataBase;
            createDatabaseForm.TestClientIsOneBase += DataBaseConstants.TestClientIsOneBase;
            createDatabaseForm.ShowDialog();
        }

        private void AdminBuilderForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            ConfigurationManager.WriteConfigToJson();
        }


    }
}
