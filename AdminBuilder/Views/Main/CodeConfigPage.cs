using AdminBuilder.Model;
using AdminBuilder.Service.DataModel;
using AdminBuilder.Utils;
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
    public partial class CodeConfigPage : UIPage,IEventListener
    {
        public TDataView<VueModelInfo> DataView = new TDataView<VueModelInfo>();
        public readonly IDataModelService modelService;
        public CodeConfigPage(IDataModelService dataModelService)
        {
            this.DataView.Dock = DockStyle.Fill;
            this.modelService = dataModelService;
            InitializeComponent();
            InitView();
        }
        private bool RemoveModel(object id)
        {
            var data = (VueModelInfo)id;
            return modelService.DeleteVueDataModel(data.Id);
        }

        public void InitView()
        {
            DataView.EditFunc += modelService.GetAllVueDataModel;
            DataView.SetUpdate(modelService.UpdateVueDataModel);
            DataView.SetRemove(RemoveModel);
            DataView.SetAdd(modelService.AddVueDataModel);
            DataView.InitForm(modelService.GetAllVueDataModel(1));
            this.Controls.Add(DataView);
        }

        public void HandleEvent(string eventType, DataRefreshEventArgs args)
        {
            throw new NotImplementedException();
        }
    }
}
