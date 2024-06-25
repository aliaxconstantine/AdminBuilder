using AdminBuilder.Model;
using AdminBuilder.Service.DataModel;
using AdminBuilder.Utils.ControlEvent;
using DataEvent.Utils.ControlEvent;
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
    public partial class ApiConfigPage : UIPage, IEventListener
    {
        public TDataView<ApiModelInfo> DataView = new TDataView<ApiModelInfo>();
        public readonly IDataModelService modelService;
        public ApiConfigPage(IDataModelService modelService)
        {
            this.DataView.Dock = DockStyle.Fill;
            this.modelService = modelService;
            InitializeComponent();
            InitView();
        }

        private bool RemoveModel(ApiModelInfo id) 
        {
           return modelService.DeleteApiDataModel(id.Id);
        }

        public void InitView()
        {
            DataView.EditFunc += modelService.GetAllApiDataModel;
            DataView.SetUpdate(modelService.UpdateApiDataModel);
            DataView.SetRemove(RemoveModel);
            DataView.SetAdd(modelService.AddApiDataModel);
            DataView.InitForm(modelService.GetAllApiDataModel(1));
            this.Controls.Add( DataView );
        }

        public void HandleEvent(string eventType, DataRefreshEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
