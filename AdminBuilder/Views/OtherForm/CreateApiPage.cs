using AdminBuilder.Config;
using AdminBuilder.Model;
using AdminBuilder.Service.InAndOutPut;
using AdminBuilder.Service.InAndOutPut.IOutPutDTO;
using AdminBuilder.Views.Main;
using Autofac;
using Sunny.SqlSugar;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AdminBuilder.Views.OtherForm
{
    public partial class CreateApiPage : UIHeaderMainFooterFrame
    {
        public readonly ApiConfigPage ApiConfigForm;
        public readonly IOutPutService outPutService;
        public ConnectionModelInfo CurrentlyTableName;
        public Dictionary<TableBaseInfo, List<ColumnInfo>> columnInfuse = new Dictionary<TableBaseInfo, List<ColumnInfo>>();
        public CreateApiPage(ApiConfigPage apiConfigForm,IOutPutService outPutService)
        {
            InitializeComponent();
            ApiConfigForm = apiConfigForm;
            this.outPutService = outPutService;
            ApiConfigForm.Location = new Point(0, 42);
            AddPage(ApiConfigForm);
            this.uiPanel1.Dock = DockStyle.Bottom;
        }


        private void uiButton3_Click(object sender, EventArgs e)
        {
            //确认
            //获取当前选择的模板
            var models = ApiConfigForm.DataView.CurrentlySelect;

            var outDTo = new List<OutPutTableDTO>();
            columnInfuse.ForEach(t =>
            {
                outDTo.Add(new OutPutTableDTO()
                {
                    TableName = t.Key.TableName,
                    calumnious = t.Value,
                    DataBaseType = CurrentlyTableName.ConnectionType,
                    StringType = GetStringType(CurrentlyTableName.ConnectionNameType)
                }) ; 
            });
            models.ForEach(t =>
            {
                outDTo.ForEach(s =>
                {
                    outPutService.OutPutApi(s, t);
                });
            });
            UIMessageTip.Show("生成成功");
        }

        private StringType GetStringType(string input)
        {
            switch(input)
            {
                case "大写":return StringType.Upper;
                case "小写":return StringType.Lower;
                case "下划线":return StringType.Underscore;
                default: return StringType.Upper;
            }
        }

        private void uiPanel1_Click(object sender, EventArgs e)
        {

        }

        private void uiButton4_Click(object sender, EventArgs e)
        {
            //取消
            this.Close();
            UIMessageTip.Show("取消操作");
        }
    }
}
