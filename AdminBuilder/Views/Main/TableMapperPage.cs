using AdminBuilder.Model;
using AdminBuilder.Service.Connection;
using AdminBuilder.Service.DataModel;
using AdminBuilder.Service.InAndOutPut.IOutPutDTO;
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

namespace AdminBuilder.Views.Main
{
    public partial class TableMapperPage : UIPage
    {
        public TDataView<TableMapper> DataView = new TDataView<TableMapper>();
        public readonly IDataModelService dataModel;
        public TableMapperPage(IDataModelService modelService)
        {
            this.dataModel = modelService;
            this.DataView.Dock = DockStyle.Fill;
            InitializeComponent();
            InitView();
        }

        public void InitView()
        {
            DataView.EditFunc += dataModel.GetTableMappers;
            DataView.SetAdd(dataModel.AddTableMapper);
            DataView.SetUpdate(dataModel.UpdateTableMapper);
            DataView.SetRemove(dataModel.DeleteTableMapper);
            DataView.InitForm(dataModel.GetTableMappers(1));
            this.Controls.Add(DataView);
        }
    }
}
